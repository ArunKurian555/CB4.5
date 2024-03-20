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

namespace UserModule_SCHEDULER_CH5_V3
{
    public class UserModuleClass_SCHEDULER_CH5_V3 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        short FILEHANDLE = 0;
        Crestron.Logos.SplusObjects.DigitalInput START;
        Crestron.Logos.SplusObjects.DigitalInput SAVE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MO;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> TU;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> WE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> TH;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FR;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SA;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SU;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MOFB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> TUFB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> WEFB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> THFB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> FRFB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SAFB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SUFB;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> EVENTCHANGE;
        Crestron.Logos.SplusObjects.StringOutput SERIAL;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> EVENTS;
        ushort A = 0;
        ushort B = 0;
        ushort I = 0;
        ushort J = 0;
        ushort C = 0;
        ushort D = 0;
        ushort K = 0;
        ushort INCHAR = 0;
        ushort [] ANALOG;
        short RESULT = 0;
        CrestronString TEMP;
        CrestronString TEMP2;
        CrestronString TEMP3;
        CrestronString FNAME;
        CrestronString SBUF;
        CrestronString [] DAYSTEMP;
        CrestronString [] DAYS;
        CrestronString NIL;
        private void SAVETODISK (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 24;
            SBUF  .UpdateValue ( "#2\r\n"  ) ; 
            __context__.SourceCodeLine = 25;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)8; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 27;
                SBUF  .UpdateValue ( SBUF + EVENTCHANGE [ I ] + "\r\n"  ) ; 
                __context__.SourceCodeLine = 25;
                } 
            
            __context__.SourceCodeLine = 29;
            MakeString ( FNAME , "\\NVRAM\\scheduler1.txt") ; 
            __context__.SourceCodeLine = 31;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 32;
            FileDelete ( FNAME ) ; 
            __context__.SourceCodeLine = 33;
            FILEHANDLE = (short) ( FileOpen( FNAME ,(ushort) (((256 | 2) | 16384) | 8) ) ) ; 
            __context__.SourceCodeLine = 34;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FILEHANDLE >= 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 35;
                FileWrite (  (short) ( FILEHANDLE ) , SBUF ,  (ushort) ( 8192 ) ) ; 
                }
            
            __context__.SourceCodeLine = 36;
            FileClose (  (short) ( FILEHANDLE ) ) ; 
            __context__.SourceCodeLine = 37;
            EndFileOperations ( ) ; 
            
            }
            
        private void RETRIVE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 47;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 48;
            MakeString ( FNAME , "\\NVRAM\\scheduler1.txt") ; 
            __context__.SourceCodeLine = 49;
            FILEHANDLE = (short) ( FileOpen( FNAME ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 50;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FILEHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 52;
                FileRead (  (short) ( FILEHANDLE ) , SBUF ,  (ushort) ( 4096 ) ) ; 
                __context__.SourceCodeLine = 53;
                FileSeek (  (short) ( FILEHANDLE ) ,  (uint) ( 0 ) ,  (ushort) ( 0 ) ) ; 
                __context__.SourceCodeLine = 54;
                FileClose (  (short) ( FILEHANDLE ) ) ; 
                __context__.SourceCodeLine = 55;
                EndFileOperations ( ) ; 
                } 
            
            __context__.SourceCodeLine = 59;
            B = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 60;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)20; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 62;
                A = (ushort) ( Functions.Find( "\r\n" , SBUF , B ) ) ; 
                __context__.SourceCodeLine = 63;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (A != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 65;
                    TEMP  .UpdateValue ( Functions.Mid ( SBUF ,  (int) ( B ) ,  (int) ( (A - B) ) )  ) ; 
                    __context__.SourceCodeLine = 66;
                    EVENTS [ I]  .UpdateValue ( TEMP  ) ; 
                    __context__.SourceCodeLine = 69;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I > 1 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 73;
                        D = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 74;
                        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__2 = (ushort)20; 
                        int __FN_FORSTEP_VAL__2 = (int)1; 
                        for ( J  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (J  >= __FN_FORSTART_VAL__2) && (J  <= __FN_FOREND_VAL__2) ) : ( (J  <= __FN_FORSTART_VAL__2) && (J  >= __FN_FOREND_VAL__2) ) ; J  += (ushort)__FN_FORSTEP_VAL__2) 
                            { 
                            __context__.SourceCodeLine = 76;
                            C = (ushort) ( Functions.Find( "," , TEMP , D ) ) ; 
                            __context__.SourceCodeLine = 77;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (C != 0))  ) ) 
                                { 
                                __context__.SourceCodeLine = 79;
                                TEMP2  .UpdateValue ( Functions.Mid ( TEMP ,  (int) ( D ) ,  (int) ( (C - D) ) )  ) ; 
                                __context__.SourceCodeLine = 80;
                                DAYS [ J ]  .UpdateValue ( TEMP2  ) ; 
                                __context__.SourceCodeLine = 81;
                                D = (ushort) ( (C + 1) ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 74;
                            } 
                        
                        __context__.SourceCodeLine = 88;
                        INCHAR = (ushort) ( Functions.GetC( DAYS[ 5 ] ) ) ; 
                        __context__.SourceCodeLine = 89;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
                            {
                            __context__.SourceCodeLine = 90;
                            SUFB [ (I - 1)]  .Value = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 92;
                            SUFB [ (I - 1)]  .Value = (ushort) ( 0 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 94;
                        INCHAR = (ushort) ( Functions.GetC( DAYS[ 5 ] ) ) ; 
                        __context__.SourceCodeLine = 95;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
                            {
                            __context__.SourceCodeLine = 96;
                            MOFB [ (I - 1)]  .Value = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 98;
                            MOFB [ (I - 1)]  .Value = (ushort) ( 0 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 100;
                        INCHAR = (ushort) ( Functions.GetC( DAYS[ 5 ] ) ) ; 
                        __context__.SourceCodeLine = 101;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
                            {
                            __context__.SourceCodeLine = 102;
                            TUFB [ (I - 1)]  .Value = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 104;
                            TUFB [ (I - 1)]  .Value = (ushort) ( 0 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 106;
                        INCHAR = (ushort) ( Functions.GetC( DAYS[ 5 ] ) ) ; 
                        __context__.SourceCodeLine = 107;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
                            {
                            __context__.SourceCodeLine = 108;
                            WEFB [ (I - 1)]  .Value = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 110;
                            WEFB [ (I - 1)]  .Value = (ushort) ( 0 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 112;
                        INCHAR = (ushort) ( Functions.GetC( DAYS[ 5 ] ) ) ; 
                        __context__.SourceCodeLine = 113;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
                            {
                            __context__.SourceCodeLine = 114;
                            THFB [ (I - 1)]  .Value = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 116;
                            THFB [ (I - 1)]  .Value = (ushort) ( 0 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 118;
                        INCHAR = (ushort) ( Functions.GetC( DAYS[ 5 ] ) ) ; 
                        __context__.SourceCodeLine = 119;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
                            {
                            __context__.SourceCodeLine = 120;
                            FRFB [ (I - 1)]  .Value = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 122;
                            FRFB [ (I - 1)]  .Value = (ushort) ( 0 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 124;
                        INCHAR = (ushort) ( Functions.GetC( DAYS[ 5 ] ) ) ; 
                        __context__.SourceCodeLine = 125;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
                            {
                            __context__.SourceCodeLine = 126;
                            SAFB [ (I - 1)]  .Value = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 128;
                            SAFB [ (I - 1)]  .Value = (ushort) ( 0 ) ; 
                            }
                        
                        } 
                    
                    __context__.SourceCodeLine = 139;
                    B = (ushort) ( (A + 2) ) ; 
                    } 
                
                __context__.SourceCodeLine = 60;
                } 
            
            
            }
            
        object SAVE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 156;
                SAVETODISK (  __context__  ) ; 
                __context__.SourceCodeLine = 157;
                RETRIVE (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object START_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 163;
            RETRIVE (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SU_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 174;
        A = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 175;
        TEMP  .UpdateValue ( EVENTCHANGE [ A ]  ) ; 
        __context__.SourceCodeLine = 180;
        D = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 181;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)20; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 183;
            C = (ushort) ( Functions.Find( "," , TEMP , D ) ) ; 
            __context__.SourceCodeLine = 184;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (C != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 186;
                TEMP2  .UpdateValue ( Functions.Mid ( TEMP ,  (int) ( D ) ,  (int) ( (C - D) ) )  ) ; 
                __context__.SourceCodeLine = 187;
                DAYS [ J ]  .UpdateValue ( TEMP2  ) ; 
                __context__.SourceCodeLine = 188;
                D = (ushort) ( (C + 1) ) ; 
                } 
            
            __context__.SourceCodeLine = 181;
            } 
        
        __context__.SourceCodeLine = 193;
        DAYSTEMP [ 5 ]  .UpdateValue ( DAYS [ 5 ]  ) ; 
        __context__.SourceCodeLine = 195;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 196;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 198;
            TEMP2  .UpdateValue ( "-"  ) ; 
            __context__.SourceCodeLine = 199;
            SUFB [ A]  .Value = (ushort) ( 0 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 204;
            TEMP2  .UpdateValue ( "X"  ) ; 
            __context__.SourceCodeLine = 205;
            SUFB [ A]  .Value = (ushort) ( 1 ) ; 
            } 
        
        __context__.SourceCodeLine = 208;
        DAYS [ 5 ]  .UpdateValue ( TEMP2 + DAYSTEMP [ 5 ]  ) ; 
        __context__.SourceCodeLine = 213;
        EVENTCHANGE [ A ]  .UpdateValue ( DAYS [ 1 ] + "," + DAYS [ 2 ] + "," + DAYS [ 3 ] + "," + DAYS [ 4 ] + "," + DAYS [ 5 ] + "," + DAYS [ 6 ] + "," + DAYS [ 7 ] + "," + DAYS [ 8 ]  ) ; 
        __context__.SourceCodeLine = 216;
        SAVETODISK (  __context__  ) ; 
        __context__.SourceCodeLine = 217;
        RETRIVE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MO_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 226;
        A = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 227;
        TEMP  .UpdateValue ( EVENTCHANGE [ A ]  ) ; 
        __context__.SourceCodeLine = 232;
        D = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 233;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)20; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 235;
            C = (ushort) ( Functions.Find( "," , TEMP , D ) ) ; 
            __context__.SourceCodeLine = 236;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (C != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 238;
                TEMP2  .UpdateValue ( Functions.Mid ( TEMP ,  (int) ( D ) ,  (int) ( (C - D) ) )  ) ; 
                __context__.SourceCodeLine = 239;
                DAYS [ J ]  .UpdateValue ( TEMP2  ) ; 
                __context__.SourceCodeLine = 240;
                D = (ushort) ( (C + 1) ) ; 
                } 
            
            __context__.SourceCodeLine = 233;
            } 
        
        __context__.SourceCodeLine = 245;
        DAYSTEMP [ 5 ]  .UpdateValue ( DAYS [ 5 ]  ) ; 
        __context__.SourceCodeLine = 247;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 248;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 250;
            TEMP2  .UpdateValue ( "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 254;
            TEMP2  .UpdateValue ( "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 256;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 257;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 259;
            MOFB [ A]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 260;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 264;
            MOFB [ A]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 265;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        __context__.SourceCodeLine = 268;
        DAYS [ 5 ]  .UpdateValue ( TEMP2 + DAYSTEMP [ 5 ]  ) ; 
        __context__.SourceCodeLine = 273;
        EVENTCHANGE [ A ]  .UpdateValue ( DAYS [ 1 ] + "," + DAYS [ 2 ] + "," + DAYS [ 3 ] + "," + DAYS [ 4 ] + "," + DAYS [ 5 ] + "," + DAYS [ 6 ] + "," + DAYS [ 7 ] + "," + DAYS [ 8 ]  ) ; 
        __context__.SourceCodeLine = 276;
        SAVETODISK (  __context__  ) ; 
        __context__.SourceCodeLine = 277;
        RETRIVE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TU_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 291;
        A = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 292;
        TEMP  .UpdateValue ( EVENTCHANGE [ A ]  ) ; 
        __context__.SourceCodeLine = 297;
        D = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 298;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)20; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 300;
            C = (ushort) ( Functions.Find( "," , TEMP , D ) ) ; 
            __context__.SourceCodeLine = 301;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (C != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 303;
                TEMP2  .UpdateValue ( Functions.Mid ( TEMP ,  (int) ( D ) ,  (int) ( (C - D) ) )  ) ; 
                __context__.SourceCodeLine = 304;
                DAYS [ J ]  .UpdateValue ( TEMP2  ) ; 
                __context__.SourceCodeLine = 305;
                D = (ushort) ( (C + 1) ) ; 
                } 
            
            __context__.SourceCodeLine = 298;
            } 
        
        __context__.SourceCodeLine = 310;
        DAYSTEMP [ 5 ]  .UpdateValue ( DAYS [ 5 ]  ) ; 
        __context__.SourceCodeLine = 312;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 313;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 315;
            TEMP2  .UpdateValue ( "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 319;
            TEMP2  .UpdateValue ( "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 321;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 322;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 324;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 328;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 330;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 331;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 333;
            TUFB [ A]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 334;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 338;
            TUFB [ A]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 339;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        __context__.SourceCodeLine = 342;
        DAYS [ 5 ]  .UpdateValue ( TEMP2 + DAYSTEMP [ 5 ]  ) ; 
        __context__.SourceCodeLine = 347;
        EVENTCHANGE [ A ]  .UpdateValue ( DAYS [ 1 ] + "," + DAYS [ 2 ] + "," + DAYS [ 3 ] + "," + DAYS [ 4 ] + "," + DAYS [ 5 ] + "," + DAYS [ 6 ] + "," + DAYS [ 7 ] + "," + DAYS [ 8 ]  ) ; 
        __context__.SourceCodeLine = 350;
        SAVETODISK (  __context__  ) ; 
        __context__.SourceCodeLine = 351;
        RETRIVE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object WE_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 367;
        A = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 368;
        TEMP  .UpdateValue ( EVENTCHANGE [ A ]  ) ; 
        __context__.SourceCodeLine = 373;
        D = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 374;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)20; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 376;
            C = (ushort) ( Functions.Find( "," , TEMP , D ) ) ; 
            __context__.SourceCodeLine = 377;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (C != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 379;
                TEMP2  .UpdateValue ( Functions.Mid ( TEMP ,  (int) ( D ) ,  (int) ( (C - D) ) )  ) ; 
                __context__.SourceCodeLine = 380;
                DAYS [ J ]  .UpdateValue ( TEMP2  ) ; 
                __context__.SourceCodeLine = 381;
                D = (ushort) ( (C + 1) ) ; 
                } 
            
            __context__.SourceCodeLine = 374;
            } 
        
        __context__.SourceCodeLine = 386;
        DAYSTEMP [ 5 ]  .UpdateValue ( DAYS [ 5 ]  ) ; 
        __context__.SourceCodeLine = 388;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 389;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 391;
            TEMP2  .UpdateValue ( "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 395;
            TEMP2  .UpdateValue ( "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 397;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 398;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 400;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 404;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 406;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 407;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 409;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 413;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 415;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 416;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 418;
            WEFB [ A]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 419;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 423;
            WEFB [ A]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 424;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        __context__.SourceCodeLine = 427;
        DAYS [ 5 ]  .UpdateValue ( TEMP2 + DAYSTEMP [ 5 ]  ) ; 
        __context__.SourceCodeLine = 432;
        EVENTCHANGE [ A ]  .UpdateValue ( DAYS [ 1 ] + "," + DAYS [ 2 ] + "," + DAYS [ 3 ] + "," + DAYS [ 4 ] + "," + DAYS [ 5 ] + "," + DAYS [ 6 ] + "," + DAYS [ 7 ] + "," + DAYS [ 8 ]  ) ; 
        __context__.SourceCodeLine = 435;
        SAVETODISK (  __context__  ) ; 
        __context__.SourceCodeLine = 436;
        RETRIVE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TH_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 442;
        A = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 443;
        TEMP  .UpdateValue ( EVENTCHANGE [ A ]  ) ; 
        __context__.SourceCodeLine = 448;
        D = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 449;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)20; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 451;
            C = (ushort) ( Functions.Find( "," , TEMP , D ) ) ; 
            __context__.SourceCodeLine = 452;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (C != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 454;
                TEMP2  .UpdateValue ( Functions.Mid ( TEMP ,  (int) ( D ) ,  (int) ( (C - D) ) )  ) ; 
                __context__.SourceCodeLine = 455;
                DAYS [ J ]  .UpdateValue ( TEMP2  ) ; 
                __context__.SourceCodeLine = 456;
                D = (ushort) ( (C + 1) ) ; 
                } 
            
            __context__.SourceCodeLine = 449;
            } 
        
        __context__.SourceCodeLine = 461;
        DAYSTEMP [ 5 ]  .UpdateValue ( DAYS [ 5 ]  ) ; 
        __context__.SourceCodeLine = 463;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 464;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 466;
            TEMP2  .UpdateValue ( "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 470;
            TEMP2  .UpdateValue ( "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 472;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 473;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 475;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 479;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 481;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 482;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 484;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 488;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 490;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 491;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 493;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 497;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 499;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 500;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 502;
            THFB [ A]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 503;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 507;
            THFB [ A]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 508;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        __context__.SourceCodeLine = 511;
        DAYS [ 5 ]  .UpdateValue ( TEMP2 + DAYSTEMP [ 5 ]  ) ; 
        __context__.SourceCodeLine = 516;
        EVENTCHANGE [ A ]  .UpdateValue ( DAYS [ 1 ] + "," + DAYS [ 2 ] + "," + DAYS [ 3 ] + "," + DAYS [ 4 ] + "," + DAYS [ 5 ] + "," + DAYS [ 6 ] + "," + DAYS [ 7 ] + "," + DAYS [ 8 ]  ) ; 
        __context__.SourceCodeLine = 519;
        SAVETODISK (  __context__  ) ; 
        __context__.SourceCodeLine = 520;
        RETRIVE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FR_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 526;
        A = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 527;
        TEMP  .UpdateValue ( EVENTCHANGE [ A ]  ) ; 
        __context__.SourceCodeLine = 532;
        D = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 533;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)20; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 535;
            C = (ushort) ( Functions.Find( "," , TEMP , D ) ) ; 
            __context__.SourceCodeLine = 536;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (C != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 538;
                TEMP2  .UpdateValue ( Functions.Mid ( TEMP ,  (int) ( D ) ,  (int) ( (C - D) ) )  ) ; 
                __context__.SourceCodeLine = 539;
                DAYS [ J ]  .UpdateValue ( TEMP2  ) ; 
                __context__.SourceCodeLine = 540;
                D = (ushort) ( (C + 1) ) ; 
                } 
            
            __context__.SourceCodeLine = 533;
            } 
        
        __context__.SourceCodeLine = 545;
        DAYSTEMP [ 5 ]  .UpdateValue ( DAYS [ 5 ]  ) ; 
        __context__.SourceCodeLine = 547;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 548;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 550;
            TEMP2  .UpdateValue ( "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 554;
            TEMP2  .UpdateValue ( "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 556;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 557;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 559;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 563;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 565;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 566;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 568;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 572;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 574;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 575;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 577;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 581;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 583;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 584;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 586;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 590;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 593;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 594;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 596;
            FRFB [ A]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 597;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 601;
            FRFB [ A]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 602;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        __context__.SourceCodeLine = 605;
        DAYS [ 5 ]  .UpdateValue ( TEMP2 + DAYSTEMP [ 5 ]  ) ; 
        __context__.SourceCodeLine = 610;
        EVENTCHANGE [ A ]  .UpdateValue ( DAYS [ 1 ] + "," + DAYS [ 2 ] + "," + DAYS [ 3 ] + "," + DAYS [ 4 ] + "," + DAYS [ 5 ] + "," + DAYS [ 6 ] + "," + DAYS [ 7 ] + "," + DAYS [ 8 ]  ) ; 
        __context__.SourceCodeLine = 613;
        SAVETODISK (  __context__  ) ; 
        __context__.SourceCodeLine = 614;
        RETRIVE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SA_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 620;
        A = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 621;
        TEMP  .UpdateValue ( EVENTCHANGE [ A ]  ) ; 
        __context__.SourceCodeLine = 626;
        D = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 627;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)20; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 629;
            C = (ushort) ( Functions.Find( "," , TEMP , D ) ) ; 
            __context__.SourceCodeLine = 630;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (C != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 632;
                TEMP2  .UpdateValue ( Functions.Mid ( TEMP ,  (int) ( D ) ,  (int) ( (C - D) ) )  ) ; 
                __context__.SourceCodeLine = 633;
                DAYS [ J ]  .UpdateValue ( TEMP2  ) ; 
                __context__.SourceCodeLine = 634;
                D = (ushort) ( (C + 1) ) ; 
                } 
            
            __context__.SourceCodeLine = 627;
            } 
        
        __context__.SourceCodeLine = 639;
        DAYSTEMP [ 5 ]  .UpdateValue ( DAYS [ 5 ]  ) ; 
        __context__.SourceCodeLine = 641;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 642;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 644;
            TEMP2  .UpdateValue ( "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 648;
            TEMP2  .UpdateValue ( "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 650;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 651;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 653;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 657;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 659;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 660;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 662;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 666;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 668;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 669;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 671;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 675;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 677;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 678;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 680;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 684;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 686;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 687;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 689;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 693;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        __context__.SourceCodeLine = 696;
        INCHAR = (ushort) ( Functions.GetC( DAYSTEMP[ 5 ] ) ) ; 
        __context__.SourceCodeLine = 697;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INCHAR == 88))  ) ) 
            { 
            __context__.SourceCodeLine = 699;
            SAFB [ A]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 700;
            TEMP2  .UpdateValue ( TEMP2 + "-"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 704;
            SAFB [ A]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 705;
            TEMP2  .UpdateValue ( TEMP2 + "X"  ) ; 
            } 
        
        __context__.SourceCodeLine = 708;
        DAYS [ 5 ]  .UpdateValue ( TEMP2 + DAYSTEMP [ 5 ]  ) ; 
        __context__.SourceCodeLine = 713;
        EVENTCHANGE [ A ]  .UpdateValue ( DAYS [ 1 ] + "," + DAYS [ 2 ] + "," + DAYS [ 3 ] + "," + DAYS [ 4 ] + "," + DAYS [ 5 ] + "," + DAYS [ 6 ] + "," + DAYS [ 7 ] + "," + DAYS [ 8 ]  ) ; 
        __context__.SourceCodeLine = 716;
        SAVETODISK (  __context__  ) ; 
        __context__.SourceCodeLine = 717;
        RETRIVE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    ANALOG  = new ushort[ 301 ];
    TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4029, this );
    TEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4029, this );
    TEMP3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4029, this );
    FNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
    SBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
    NIL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 123, this );
    DAYSTEMP  = new CrestronString[ 1025 ];
    for( uint i = 0; i < 1025; i++ )
        DAYSTEMP [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    DAYS  = new CrestronString[ 1025 ];
    for( uint i = 0; i < 1025; i++ )
        DAYS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    
    START = new Crestron.Logos.SplusObjects.DigitalInput( START__DigitalInput__, this );
    m_DigitalInputList.Add( START__DigitalInput__, START );
    
    SAVE = new Crestron.Logos.SplusObjects.DigitalInput( SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( SAVE__DigitalInput__, SAVE );
    
    MO = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        MO[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MO__DigitalInput__ + i, MO__DigitalInput__, this );
        m_DigitalInputList.Add( MO__DigitalInput__ + i, MO[i+1] );
    }
    
    TU = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        TU[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( TU__DigitalInput__ + i, TU__DigitalInput__, this );
        m_DigitalInputList.Add( TU__DigitalInput__ + i, TU[i+1] );
    }
    
    WE = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        WE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( WE__DigitalInput__ + i, WE__DigitalInput__, this );
        m_DigitalInputList.Add( WE__DigitalInput__ + i, WE[i+1] );
    }
    
    TH = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        TH[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( TH__DigitalInput__ + i, TH__DigitalInput__, this );
        m_DigitalInputList.Add( TH__DigitalInput__ + i, TH[i+1] );
    }
    
    FR = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        FR[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FR__DigitalInput__ + i, FR__DigitalInput__, this );
        m_DigitalInputList.Add( FR__DigitalInput__ + i, FR[i+1] );
    }
    
    SA = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        SA[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SA__DigitalInput__ + i, SA__DigitalInput__, this );
        m_DigitalInputList.Add( SA__DigitalInput__ + i, SA[i+1] );
    }
    
    SU = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        SU[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SU__DigitalInput__ + i, SU__DigitalInput__, this );
        m_DigitalInputList.Add( SU__DigitalInput__ + i, SU[i+1] );
    }
    
    MOFB = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        MOFB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MOFB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MOFB__DigitalOutput__ + i, MOFB[i+1] );
    }
    
    TUFB = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        TUFB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( TUFB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( TUFB__DigitalOutput__ + i, TUFB[i+1] );
    }
    
    WEFB = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        WEFB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( WEFB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( WEFB__DigitalOutput__ + i, WEFB[i+1] );
    }
    
    THFB = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        THFB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( THFB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( THFB__DigitalOutput__ + i, THFB[i+1] );
    }
    
    FRFB = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        FRFB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( FRFB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( FRFB__DigitalOutput__ + i, FRFB[i+1] );
    }
    
    SAFB = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        SAFB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SAFB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SAFB__DigitalOutput__ + i, SAFB[i+1] );
    }
    
    SUFB = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        SUFB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SUFB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SUFB__DigitalOutput__ + i, SUFB[i+1] );
    }
    
    EVENTCHANGE = new InOutArray<StringInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        EVENTCHANGE[i+1] = new Crestron.Logos.SplusObjects.StringInput( EVENTCHANGE__AnalogSerialInput__ + i, EVENTCHANGE__AnalogSerialInput__, 1024, this );
        m_StringInputList.Add( EVENTCHANGE__AnalogSerialInput__ + i, EVENTCHANGE[i+1] );
    }
    
    SERIAL = new Crestron.Logos.SplusObjects.StringOutput( SERIAL__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SERIAL__AnalogSerialOutput__, SERIAL );
    
    EVENTS = new InOutArray<StringOutput>( 20, this );
    for( uint i = 0; i < 20; i++ )
    {
        EVENTS[i+1] = new Crestron.Logos.SplusObjects.StringOutput( EVENTS__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( EVENTS__AnalogSerialOutput__ + i, EVENTS[i+1] );
    }
    
    
    SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVE_OnPush_0, false ) );
    START.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_OnPush_1, false ) );
    for( uint i = 0; i < 10; i++ )
        SU[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SU_OnPush_2, false ) );
        
    for( uint i = 0; i < 10; i++ )
        MO[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MO_OnPush_3, false ) );
        
    for( uint i = 0; i < 10; i++ )
        TU[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( TU_OnPush_4, false ) );
        
    for( uint i = 0; i < 10; i++ )
        WE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( WE_OnPush_5, false ) );
        
    for( uint i = 0; i < 10; i++ )
        TH[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( TH_OnPush_6, false ) );
        
    for( uint i = 0; i < 10; i++ )
        FR[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FR_OnPush_7, false ) );
        
    for( uint i = 0; i < 10; i++ )
        SA[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SA_OnPush_8, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SCHEDULER_CH5_V3 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint START__DigitalInput__ = 0;
const uint SAVE__DigitalInput__ = 1;
const uint MO__DigitalInput__ = 2;
const uint TU__DigitalInput__ = 12;
const uint WE__DigitalInput__ = 22;
const uint TH__DigitalInput__ = 32;
const uint FR__DigitalInput__ = 42;
const uint SA__DigitalInput__ = 52;
const uint SU__DigitalInput__ = 62;
const uint MOFB__DigitalOutput__ = 0;
const uint TUFB__DigitalOutput__ = 10;
const uint WEFB__DigitalOutput__ = 20;
const uint THFB__DigitalOutput__ = 30;
const uint FRFB__DigitalOutput__ = 40;
const uint SAFB__DigitalOutput__ = 50;
const uint SUFB__DigitalOutput__ = 60;
const uint EVENTCHANGE__AnalogSerialInput__ = 0;
const uint SERIAL__AnalogSerialOutput__ = 0;
const uint EVENTS__AnalogSerialOutput__ = 1;

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
