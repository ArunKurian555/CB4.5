using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_SERIAL_COMPARE
{
    public class UserModuleClass_SERIAL_COMPARE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> N;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> SIN;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> SREF;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> RESETER;
        object SIN_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 17;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SIN[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] == SREF[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ]))  ) ) 
                    { 
                    __context__.SourceCodeLine = 19;
                    Functions.Pulse ( 100, N [ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )] ) ; 
                    __context__.SourceCodeLine = 20;
                    RESETER [ 1]  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 21;
                    RESETER [ 2]  .UpdateValue ( ""  ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        N = new InOutArray<DigitalOutput>( 5, this );
        for( uint i = 0; i < 5; i++ )
        {
            N[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( N__DigitalOutput__ + i, this );
            m_DigitalOutputList.Add( N__DigitalOutput__ + i, N[i+1] );
        }
        
        SIN = new InOutArray<StringInput>( 5, this );
        for( uint i = 0; i < 5; i++ )
        {
            SIN[i+1] = new Crestron.Logos.SplusObjects.StringInput( SIN__AnalogSerialInput__ + i, SIN__AnalogSerialInput__, 255, this );
            m_StringInputList.Add( SIN__AnalogSerialInput__ + i, SIN[i+1] );
        }
        
        SREF = new InOutArray<StringInput>( 5, this );
        for( uint i = 0; i < 5; i++ )
        {
            SREF[i+1] = new Crestron.Logos.SplusObjects.StringInput( SREF__AnalogSerialInput__ + i, SREF__AnalogSerialInput__, 255, this );
            m_StringInputList.Add( SREF__AnalogSerialInput__ + i, SREF[i+1] );
        }
        
        RESETER = new InOutArray<StringOutput>( 2, this );
        for( uint i = 0; i < 2; i++ )
        {
            RESETER[i+1] = new Crestron.Logos.SplusObjects.StringOutput( RESETER__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( RESETER__AnalogSerialOutput__ + i, RESETER[i+1] );
        }
        
        
        for( uint i = 0; i < 5; i++ )
            SIN[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( SIN_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_SERIAL_COMPARE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint N__DigitalOutput__ = 0;
    const uint SIN__AnalogSerialInput__ = 0;
    const uint SREF__AnalogSerialInput__ = 5;
    const uint RESETER__AnalogSerialOutput__ = 0;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
