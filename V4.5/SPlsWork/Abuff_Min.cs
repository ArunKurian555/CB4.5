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

namespace UserModule_ABUFF_MIN
{
    public class UserModuleClass_ABUFF_MIN : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.AnalogInput MINVAL;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> ANALOGI;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> ANALOGO;
        Crestron.Logos.SplusObjects.DigitalInput TRIGGER;
        object ANALOGI_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 18;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (TRIGGER  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( ANALOGI[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] .UshortValue >= MINVAL  .UshortValue ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 20;
                    ANALOGO [ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )]  .Value = (ushort) ( ANALOGI[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] .UshortValue ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        TRIGGER = new Crestron.Logos.SplusObjects.DigitalInput( TRIGGER__DigitalInput__, this );
        m_DigitalInputList.Add( TRIGGER__DigitalInput__, TRIGGER );
        
        MINVAL = new Crestron.Logos.SplusObjects.AnalogInput( MINVAL__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MINVAL__AnalogSerialInput__, MINVAL );
        
        ANALOGI = new InOutArray<AnalogInput>( 2000, this );
        for( uint i = 0; i < 2000; i++ )
        {
            ANALOGI[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( ANALOGI__AnalogSerialInput__ + i, ANALOGI__AnalogSerialInput__, this );
            m_AnalogInputList.Add( ANALOGI__AnalogSerialInput__ + i, ANALOGI[i+1] );
        }
        
        ANALOGO = new InOutArray<AnalogOutput>( 2000, this );
        for( uint i = 0; i < 2000; i++ )
        {
            ANALOGO[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( ANALOGO__AnalogSerialOutput__ + i, this );
            m_AnalogOutputList.Add( ANALOGO__AnalogSerialOutput__ + i, ANALOGO[i+1] );
        }
        
        
        for( uint i = 0; i < 2000; i++ )
            ANALOGI[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( ANALOGI_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_ABUFF_MIN ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint MINVAL__AnalogSerialInput__ = 0;
    const uint ANALOGI__AnalogSerialInput__ = 1;
    const uint ANALOGO__AnalogSerialOutput__ = 0;
    const uint TRIGGER__DigitalInput__ = 0;
    
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
