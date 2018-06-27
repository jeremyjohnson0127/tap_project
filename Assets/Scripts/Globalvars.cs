using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globalvars {


	public static int numbeofnotestotal = 0;
	public static int numberofnotesplayed = 0;

	public static int indexofnotes = 0;
	public static int numberofnotes = 0;
	public static bool pressgreen = false;
	public static bool pressblue = false;
	public static bool pressred = false;

	public static bool greenpressed = false;
	public static bool bluepressed = false;
	public static bool redpressed = false;

	public static int control1col = 0;
	public static int control2col = 0;
	public static int control3col = 0;

	public static int greenclicks = 0;
	public static int blueclicks = 0;
	public static int redclicks = 0;

	public static int correctnotes = 0;
	public static int incorrectnotes = 0;
	public static int missednotes = 0;
	public static int perfectnotes = 0;

	public static int score = 0;

	public static int streakcounter = 0;


    public static bool longgreen = false;
	public static bool longblue = false;
	public static bool longred = false;

	public static GameObject aux1;
	public static GameObject aux2;
	public static GameObject aux3;

	public static GameObject aux1blue;
	public static GameObject aux2blue;
	public static GameObject aux3blue;

	public static GameObject aux1green;
	public static GameObject aux2green;
	public static GameObject aux3green;



	public static GameObject indicator1 = null;
	public static GameObject indicator2 = null;
	public static GameObject indicator3= null;


	//public static string videoid = "p9jEizkEdis"; //"H_pRyMShJ0k"; //"p9jEizkEdis";
	public static string songpath = "/ReloadedTestTrack.chart"; //"/EverybodyTalks.chart"; //"/df_hba.chart";

	// talks
	// https://r14---sn-h5q7dn7d.googlevideo.com:443/videoplayback?key=yt6&ratebypass=yes&ipbits=0&clen=6712371&itag=18&c=WEB&requiressl=yes&mime=video/mp4&ip=2.155.84.54&pl=22&mn=sn-h5q7dn7d,sn-25ge7nsd&mm=31,26&source=youtube&ms=au,onr&id=o-AOiJdL0RJgCrg-QQb0nMDaqFoZBnBnGT8yl0RzbZAFws&mv=m&mt=1523768329&expire=1523790088&gir=yes&lmt=1518219437383610&sparams=clen,dur,ei,gir,id,initcwndbps,ip,ipbits,itag,lmt,mime,mm,mn,ms,mv,pl,ratebypass,requiressl,source,expire&ei=qNzSWsvjFsScVMfahqAF&initcwndbps=553750&fvip=3&dur=183.925&signature=02CF24D2A8B72BA4A92FD516F6AB4C0E40989FC3.AFBB97AD9861666F35544826244CAD5D17F0B4C8

	// dead f
	// https://r4---sn-h5q7rn7l.googlevideo.com:443/videoplayback?ms=au,onr&ei=Vt3SWqHJLImCVK75sPAB&mv=m&pl=22&mt=1523768505&clen=19637394&sparams=clen,dur,ei,gir,id,initcwndbps,ip,ipbits,itag,lmt,mime,mm,mn,ms,mv,pl,ratebypass,requiressl,source,expire&key=yt6&mn=sn-h5q7rn7l,sn-25glene7&mm=31,26&id=o-AMmnaZKt6kgL1Ik9d0NByiKxLtlGOr88ArN_gB6MVE2x&dur=462.773&source=youtube&ip=2.155.84.54&requiressl=yes&itag=18&lmt=1434082691518508&ipbits=0&ratebypass=yes&initcwndbps=432500&expire=1523790262&fvip=4&mime=video/mp4&gir=yes&c=WEB&signature=0412B936C805983E4805284B4CF999DDC157B024.8DE473C056C571D06CD31B7025D374D0F9E47026

	public static int speed = 12;
}
