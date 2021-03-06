/*
 * felica_nfc_dll_wrapper_basic.cs
 * Copyright 2009,2011 Sony Corporation
 */
using System;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;

/// <summary>
/// ISO 14443A情報
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct DEVICE_DATA_NFC_14443A_18092_106K
{
    /// <summary>アクセス識別子</summary>
    public UInt32 target_number;
    /// <summary>ATQA</summary>
    public UInt16 sens_res;
    /// <summary>SAK</summary>
    public byte sel_res;
    /// <summary>UIDサイズ</summary>
    public byte NFCID1_size;
    /// <summary>UID</summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public byte[] NFCID1;
    /// <summary>ATSサイズ 1443A-4以外はで0固定 ATAは1バイト</summary>
    public byte ATS_size;
    /// <summary>ATS</summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public byte[] ATS;
}

[StructLayout(LayoutKind.Sequential)]
internal struct DEVICE_DATA_NFC_14443B_106K
{
    public UInt32 target_number;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
    public byte[] ATQB;
    public byte ATTRIB_size;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public byte[] ATTRIB;
}

[StructLayout(LayoutKind.Sequential)]
internal struct DEVICE_DATA_NFC_18092_212_424K
{
    public byte id;
    public UInt32 target_number;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] NFCID2;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] Pad;
    public byte RD_size;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public byte[] RD;
}

/// <summary>
/// ウインドウメッセージで受け取るカード情報
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct DEVICE_INFO
{
    public UInt32 target_device;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public byte[] dev_info;
}

internal class felica_nfc_dll_wrapper
{
    //DllImport
    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_initialize();

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_uninitialize();

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_open(StringBuilder port_name);

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_close();

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_start_poll_mode(UInt32 target_device);

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_stop_poll_mode();

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_start_dev_access(UInt32 target_number);

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_stop_dev_access(UInt32 stop_mode);

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_select_device();

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_deselect_device();

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_thru(
            byte[] command_packet_data,
            UInt16 command_packet_data_length,
            byte[] response_packet_data,
        ref UInt16 response_packet_data_length);

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_set_timeout(UInt32 timeout);

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_get_timeout(ref UInt32 timeout);

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_set_poll_callback_parameters(
        IntPtr handle,
        String msg_str_of_find,
        String msg_str_of_enable);

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_set_pnp_callback_parameters(
        IntPtr handle,
        String msg_str_of_find,
        String msg_str_of_loss);

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_start_plug_and_play();

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_stop_plug_and_play();

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_get_last_error(UInt32[] error_info);

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_start_logging(String filename);

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_stop_logging();

    [DllImport("felica_nfc_library.dll")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool felicalib_nfc_poll_and_start_dev_access(
        UInt32 target_device,
        UInt32 timeout,
        ref IntPtr p_device_info);

    //Wrapper functions
    public bool FeliCaLibNfcInitialize(){
		return felicalib_nfc_initialize();
	}

    public bool FeliCaLibNfcUninitialize(){
        return felicalib_nfc_uninitialize();
    }

    public bool FeliCaLibNfcOpen(ref StringBuilder port_name){
        return felicalib_nfc_open(port_name);
    }

    public bool FeliCaLibNfcClose(){
        return felicalib_nfc_close();
    }

    public bool FeliCaLibNfcStartPollMode(
        UInt32 target_device){
        return felicalib_nfc_start_poll_mode(
            target_device);
    }

    public bool FeliCaLibNfcStopPollMode(){
        return felicalib_nfc_stop_poll_mode();
    }

    public bool FeliCaLibNfcStartDevAccess
        (UInt32 target_number){
        return felicalib_nfc_start_dev_access(
            target_number);
    }

    public bool FeliCaLibNfcStopDevAccess(
        UInt32 stop_mode){
        return felicalib_nfc_stop_dev_access(
            stop_mode);
    }

    public bool FeliCaLibNfcSelectDevice(){
        return felicalib_nfc_select_device();
    }

    public bool FeliCaLibNfcDeselectDevice(){
        return felicalib_nfc_deselect_device();
    }

    public bool FeliCaLibNfcThru(
            byte[] command_packet_data,
            UInt16 command_packet_data_length,
            byte[] response_packet_data,
        ref UInt16 response_packet_data_length){
        return felicalib_nfc_thru(
                command_packet_data,
                command_packet_data_length,
                response_packet_data,
            ref response_packet_data_length);
    }

    public bool FeliCaLibNfcSetTimeout(
        UInt32 timeout){
        return felicalib_nfc_set_timeout(
            timeout);
    }

    public bool FeliCaLibNfcGetTimeout(
        ref UInt32 timeout){
        return felicalib_nfc_get_timeout(
            ref timeout);
    }

    public bool FeliCaLibNfcSetPollCallbackParameters(
        IntPtr handle,
        String msg_str_of_find,
        String msg_str_of_enable){
        return felicalib_nfc_set_poll_callback_parameters(
            handle,
            msg_str_of_find,
            msg_str_of_enable);
    }

    public bool FeliCaLibNfcSetPnpCallbackParameters(
        IntPtr handle,
        String msg_str_of_find,
        String msg_str_of_loss){
        return felicalib_nfc_set_pnp_callback_parameters(
            handle,
            msg_str_of_find,
            msg_str_of_loss);
    }

    public bool FeliCaLibNfcStartPlugAndPlay(){
        return felicalib_nfc_start_plug_and_play();
    }

    public bool FeliCaLibNfcStopPlugAndPlay(){
        return felicalib_nfc_stop_plug_and_play();
    }

    public bool FeliCaLibNfcGetLastError(
        UInt32[] error_info){
        return felicalib_nfc_get_last_error(
            error_info);
    }

    public bool FeliCaLibNfcStartLogging(
        String filename){
        return felicalib_nfc_start_logging(
            filename);
    }

    public bool FeliCaLibNfcStopLogging(){
        return felicalib_nfc_stop_logging();
    }

    public bool FeliCaLibNfcPollAndStartDevAccess(UInt32 timeout, out DEVICE_DATA_NFC_14443A_18092_106K deviceInfo)
    {
        IntPtr info = IntPtr.Zero;
        bool res = felicalib_nfc_poll_and_start_dev_access(DEVICE_TYPE_NFC_14443A_18092_106K, timeout, ref info);
        if (res)
        {
            IntPtr pDevInfo = info;
            IntPtr pDeviceData_A;
            if (IntPtr.Size == 8)
            {
                pDeviceData_A = (IntPtr)((Int64)pDevInfo
                    + (Int64)Marshal.OffsetOf(typeof(DEVICE_INFO), "dev_info"));
            }
            else
            {
                pDeviceData_A = (IntPtr)((Int32)pDevInfo
                    + (Int32)Marshal.OffsetOf(typeof(DEVICE_INFO), "dev_info"));
            }

            DEVICE_DATA_NFC_14443A_18092_106K deviceA =
                (DEVICE_DATA_NFC_14443A_18092_106K)
                Marshal.PtrToStructure(pDeviceData_A,
                typeof(DEVICE_DATA_NFC_14443A_18092_106K));
            deviceInfo = deviceA;
            return true;
        }
        else
        {
            deviceInfo = new DEVICE_DATA_NFC_14443A_18092_106K();
            return false;
        }
    }

    public const Int32 DEVICE_TYPE_NFC_14443A_18092_106K = 0x01;
    public const Int32 RE_NOTIFICATION_SAME_DEVICE = 0x00000000;
}