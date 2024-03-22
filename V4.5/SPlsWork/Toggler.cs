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

namespace UserModule_TOGGLER
{
    public class UserModuleClass_TOGGLER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.AnalogInput ANALOGI;
        Crestron.Logos.SplusObjects.AnalogOutput ANALOGO;
        Crestron.Logos.SplusObjects.DigitalInput I;
        object I_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 13;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ANALOGI  .UshortValue > 0 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 14;
                    ANALOGO  .Value = (ushort) ( 0 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 16;
                    ANALOGO  .Value = (ushort) ( 65535 ) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        I = new Crestron.Logos.SplusObjects.DigitalInput( I__DigitalInput__, this );
        m_DigitalInputList.Add( I__DigitalInput__, I );
        
        ANALOGI = new Crestron.Logos.SplusObjects.AnalogInput( ANALOGI__AnalogSerialInput__, this );
        m_AnalogInputList.Add( ANALOGI__AnalogSerialInput__, ANALOGI );
        
        ANALOGO = new Crestron.Logos.SplusObjects.AnalogOutput( ANALOGO__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( ANALOGO__AnalogSerialOutput__, ANALOGO );
        
        
        I.OnDigitalPush.Add( new InputChangeHandlerWrapper( I_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_TOGGLER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint ANALOGI__AnalogSerialInput__ = 0;
    const uint ANALOGO__AnalogSerialOutput__ = 0;
    const uint I__DigitalInput__ = 0;
    
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
