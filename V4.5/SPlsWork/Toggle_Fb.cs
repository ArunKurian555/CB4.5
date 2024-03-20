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

namespace UserModule_TOGGLE_FB
{
    public class UserModuleClass_TOGGLE_FB : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput FB;
        Crestron.Logos.SplusObjects.DigitalInput FB2;
        Crestron.Logos.SplusObjects.DigitalInput CLOCK;
        Crestron.Logos.SplusObjects.DigitalInput SETD;
        Crestron.Logos.SplusObjects.DigitalInput RESETD;
        Crestron.Logos.SplusObjects.DigitalOutput TOGGLED;
        object CLOCK_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 18;
                TOGGLED  .Value = (ushort) ( Functions.Not( FB  .Value ) ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SETD_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 24;
            TOGGLED  .Value = (ushort) ( 1 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object RESETD_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 30;
        TOGGLED  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FB2_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 36;
        TOGGLED  .Value = (ushort) ( FB2  .Value ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    FB = new Crestron.Logos.SplusObjects.DigitalInput( FB__DigitalInput__, this );
    m_DigitalInputList.Add( FB__DigitalInput__, FB );
    
    FB2 = new Crestron.Logos.SplusObjects.DigitalInput( FB2__DigitalInput__, this );
    m_DigitalInputList.Add( FB2__DigitalInput__, FB2 );
    
    CLOCK = new Crestron.Logos.SplusObjects.DigitalInput( CLOCK__DigitalInput__, this );
    m_DigitalInputList.Add( CLOCK__DigitalInput__, CLOCK );
    
    SETD = new Crestron.Logos.SplusObjects.DigitalInput( SETD__DigitalInput__, this );
    m_DigitalInputList.Add( SETD__DigitalInput__, SETD );
    
    RESETD = new Crestron.Logos.SplusObjects.DigitalInput( RESETD__DigitalInput__, this );
    m_DigitalInputList.Add( RESETD__DigitalInput__, RESETD );
    
    TOGGLED = new Crestron.Logos.SplusObjects.DigitalOutput( TOGGLED__DigitalOutput__, this );
    m_DigitalOutputList.Add( TOGGLED__DigitalOutput__, TOGGLED );
    
    
    CLOCK.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLOCK_OnPush_0, false ) );
    SETD.OnDigitalPush.Add( new InputChangeHandlerWrapper( SETD_OnPush_1, false ) );
    RESETD.OnDigitalPush.Add( new InputChangeHandlerWrapper( RESETD_OnPush_2, false ) );
    FB2.OnDigitalChange.Add( new InputChangeHandlerWrapper( FB2_OnChange_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_TOGGLE_FB ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint FB__DigitalInput__ = 0;
const uint FB2__DigitalInput__ = 1;
const uint CLOCK__DigitalInput__ = 2;
const uint SETD__DigitalInput__ = 3;
const uint RESETD__DigitalInput__ = 4;
const uint TOGGLED__DigitalOutput__ = 0;

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
