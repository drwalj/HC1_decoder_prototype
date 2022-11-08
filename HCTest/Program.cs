﻿// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.IO.Compression;
using PeterO.Cbor;
using ZXing;
using Com.AugustCellars.COSE;
using Ionic.Zlib;
using NL.MinVWS.Encoding;
using ZXing.QrCode;
using System.Reflection.PortableExecutable;
using ZXing.QrCode.Internal;
using static System.Net.Mime.MediaTypeNames;
using ZXing.Common;
using System.Collections;
using QRCodeDecoderLibrary;
using IronBarCode;
//using IronBarCode;

//var barcodeBitmap = (Bitmap)Bitmap.FromFile(@"D:/Downloads/qrc.png");
//byte[] bytes = File.ReadAllBytes(@"D:/Downloads/qrc.png");

//QRDecoder Decoder = new QRDecoder();
//var ResultArray = Decoder.ImageDecoder(barcodeBitmap);

//QRCodeReader reader = new QRCodeReader();
//string TextResult = QRCode.ByteArrayToStr(ResultArray[Index].DataArray);
////BinaryBitmap img = new BinaryBitmap(source);
//var barcodeReader = new QRCodeReader();
//var qrcontent = barcodeReader.decode(barcodeBitmap).Text;


string qrcontent = "HC1:NCFOXN%TS3DH3ZSUZK+.V0ETD%65NL-AH-R6IOO6+IUKRG*I.I5BROCWAAT4V22F/8X*G3M9JUPY0BX/KR96R/S09T./0LWTKD33236J3TA3M*4VV2 73-E3GG396B-43O058YIB73A*G3W19UEBY5:PI0EGSP4*2DN43U*0CEBQ/GXQFY73CIBC:G 7376BXBJBAJ UNFMJCRN0H3PQN*E33H3OA70M3FMJIJN523.K5QZ4A+2XEN QT QTHC31M3+E32R44$28A9H0D3ZCL4JMYAZ+S-A5$XKX6T2YC 35H/ITX8GL2-LH/CJTK96L6SR9MU9RFGJA6Q3QR$P2OIC0JVLA8J3ET3:H3A+2+33U SAAUOT3TPTO4UBZIC0JKQTL*QDKBO.AI9BVYTOCFOPS4IJCOT0$89NT2V457U8+9W2KQ-7LF9-DF07U$B97JJ1D7WKP/HLIJLRKF1MFHJP7NVDEBU1J*Z222E.GJF67Z JA6B.38O4BH*HB0EGLE2%V -3O+J3.PI2G:M1SSP2Y3D38-G9C+Q3OT/.J1CDLKOYUV5C3W1A:75S4LB:6REPKM3ZYO4+QDNDLT2*ESLIH";
var qrmessage = qrcontent.Substring(4);//remove first 4 chars

byte[] decodedBase45 = Base45Encoding.Decode(qrmessage);//using base45 lib
var cose = ZlibStream.UncompressBuffer(decodedBase45);//using zlib or similar

var decrypted = Message.DecodeFromBytes(cose).GetContent(); //using COSE
CBORObject cbor = CBORObject.DecodeFromBytes(decrypted);    //using Peter.O.. CBOR

var jsonDecoded = cbor.ToJSONString(); //or deserialize it to custom class
Console.WriteLine(cbor);
Console.WriteLine(jsonDecoded);