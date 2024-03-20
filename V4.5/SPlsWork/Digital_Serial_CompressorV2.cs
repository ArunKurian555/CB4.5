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

namespace UserModule_DIGITAL_SERIAL_COMPRESSORV2
{
    public class UserModuleClass_DIGITAL_SERIAL_COMPRESSORV2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CONVERT;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DIGITAL;
        Crestron.Logos.SplusObjects.StringOutput SERIAL;
        object CONVERT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                CrestronString COMMAND;
                CrestronString TEMP;
                COMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
                TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
                
                ushort [] ANALOG;
                ANALOG  = new ushort[ 301 ];
                
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 18;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)300; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 20;
                    if ( Functions.TestForTrue  ( ( IsSignalDefined( DIGITAL[ I ] ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 22;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIGITAL[ I ] .Value == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 24;
                            ANALOG [ I] = (ushort) ( 1 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 26;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIGITAL[ I ] .Value == 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 28;
                            ANALOG [ I] = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 31;
                        COMMAND  .UpdateValue ( Functions.ItoA (  (int) ( ANALOG[ I ] ) )  ) ; 
                        __context__.SourceCodeLine = 32;
                        TEMP  .UpdateValue ( TEMP + COMMAND  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 18;
                    } 
                
                __context__.SourceCodeLine = 35;
                SERIAL  .UpdateValue ( TEMP  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        CONVERT = new Crestron.Logos.SplusObjects.DigitalInput( CONVERT__DigitalInput__, this );
        m_DigitalInputList.Add( CONVERT__DigitalInput__, CONVERT );
        
        DIGITAL = new InOutArray<DigitalInput>( 300, this );
        for( uint i = 0; i < 300; i++ )
        {
            DIGITAL[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DIGITAL__DigitalInput__ + i, DIGITAL__DigitalInput__, this );
            m_DigitalInputList.Add( DIGITAL__DigitalInput__ + i, DIGITAL[i+1] );
        }
        
        SERIAL = new Crestron.Logos.SplusObjects.StringOutput( SERIAL__AnalogSerialOutput__, this );
        m_StringOutputList.Add( SERIAL__AnalogSerialOutput__, SERIAL );
        
        
        CONVERT.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONVERT_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_DIGITAL_SERIAL_COMPRESSORV2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint CONVERT__DigitalInput__ = 0;
    const uint DIGITAL__DigitalInput__ = 1;
    const uint SERIAL__AnalogSerialOutput__ = 0;
    
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
