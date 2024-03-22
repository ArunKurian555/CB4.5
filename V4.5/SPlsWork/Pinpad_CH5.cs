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

namespace UserModule_PINPAD_CH5
{
    public class UserModuleClass_PINPAD_CH5 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> N;
        Crestron.Logos.SplusObjects.StringInput SIN;
        Crestron.Logos.SplusObjects.StringInput SDIALOGIN;
        Crestron.Logos.SplusObjects.StringOutput SOUT;
        Crestron.Logos.SplusObjects.StringOutput SDIALOG;
        CrestronString TEMP;
        object N_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 18;
                TEMP  .UpdateValue ( Functions.ItoA (  (int) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) )  ) ; 
                __context__.SourceCodeLine = 21;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) == 10))  ) ) 
                    {
                    __context__.SourceCodeLine = 22;
                    TEMP  .UpdateValue ( "0"  ) ; 
                    }
                
                __context__.SourceCodeLine = 26;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SIN ) < 4 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 28;
                    SOUT  .UpdateValue ( SIN + TEMP  ) ; 
                    __context__.SourceCodeLine = 29;
                    SDIALOG  .UpdateValue ( SDIALOGIN + " O "  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 34;
                    SOUT  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 35;
                    SDIALOG  .UpdateValue ( ""  ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        N = new InOutArray<DigitalInput>( 10, this );
        for( uint i = 0; i < 10; i++ )
        {
            N[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( N__DigitalInput__ + i, N__DigitalInput__, this );
            m_DigitalInputList.Add( N__DigitalInput__ + i, N[i+1] );
        }
        
        SIN = new Crestron.Logos.SplusObjects.StringInput( SIN__AnalogSerialInput__, 255, this );
        m_StringInputList.Add( SIN__AnalogSerialInput__, SIN );
        
        SDIALOGIN = new Crestron.Logos.SplusObjects.StringInput( SDIALOGIN__AnalogSerialInput__, 255, this );
        m_StringInputList.Add( SDIALOGIN__AnalogSerialInput__, SDIALOGIN );
        
        SOUT = new Crestron.Logos.SplusObjects.StringOutput( SOUT__AnalogSerialOutput__, this );
        m_StringOutputList.Add( SOUT__AnalogSerialOutput__, SOUT );
        
        SDIALOG = new Crestron.Logos.SplusObjects.StringOutput( SDIALOG__AnalogSerialOutput__, this );
        m_StringOutputList.Add( SDIALOG__AnalogSerialOutput__, SDIALOG );
        
        
        for( uint i = 0; i < 10; i++ )
            N[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( N_OnPush_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_PINPAD_CH5 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint N__DigitalInput__ = 0;
    const uint SIN__AnalogSerialInput__ = 0;
    const uint SDIALOGIN__AnalogSerialInput__ = 1;
    const uint SOUT__AnalogSerialOutput__ = 0;
    const uint SDIALOG__AnalogSerialOutput__ = 1;
    
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
