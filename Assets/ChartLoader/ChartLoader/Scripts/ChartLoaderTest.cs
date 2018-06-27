using UnityEngine;
using System.Collections;
using ChartLoader.NET.Framework;
using ChartLoader.NET.Utils;

public class ChartLoaderTest : MonoBehaviour {

	public static Note[] notelist; 
	public static string currentDifficulty;
    /// <summary>
    /// The current associated chart.
    /// </summary>
    public static Chart Chart;
	public static bool regenerating = true;
	public static int regeneratingsignal = 20;
	public static int notestogenerate = 50;

    /// <summary>
    /// Enumerator for all major difficulties.
    /// </summary>listofnot
    public enum Difficulty
    {
        EasyGuitar,
        MediumGuitar,
        HardGuitar,
        ExpertGuitar,
        EasyDrums,
        MediumDrums,
        HardDrums,
        ExpertDrums
    }

    public Difficulty difficulty;

    [SerializeField]
    private float _speed = 1f;
    /// <summary>
    /// The game speed.
    /// </summary>
    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }

    [SerializeField]
    private Transform[] _solidNotes;
    /// <summary>
    /// The note prefabs to be instantiated.
    /// </summary>
    public Transform[] SolidNotes
    {
        get 
        { 
            return _solidNotes; 
        }
        set 
        { 
            _solidNotes = value; 
        }
    }

    [SerializeField]
    private string _path;
    /// <summary>
    /// The current path of the chart file.
    /// </summary>
    public string Path
    {
        get 
        {
            return _path; 
        }
        set 
        {
            _path = value; 
        }
    }

    [SerializeField]
    private CameraMovement _cameraMovement;
    /// <summary>
    /// Camera movement aggregation.
    /// </summary>
    public CameraMovement CameraMovement
    {
        get 
        { 
            return _cameraMovement; 
        }
        set 
        { 
            _cameraMovement = value; 
        }
    }

    [SerializeField]
    private AudioSource _music;
    /// <summary>
    /// The music audio source.
    /// </summary>
    public AudioSource Music
    {
        get 
        { 
            return _music; 
        }
        set 
        { 
            _music = value; 
        }
    }

    [SerializeField]
    private Transform _starPowerPrefab;
    /// <summary>
    /// The star power prefab instantiated should there be any star power at all.
    /// </summary>
    public Transform StarPowerPrefab
    {
        get 
        { 
            return _starPowerPrefab; 
        }
        set 
        { 
            _starPowerPrefab = value; 
        }
    }

    [SerializeField]
    private Transform _sectionPrefab;
    /// <summary>
    /// The section prefab instantiated should there be any sections at all.
    /// </summary>
    public Transform SectionPrefab
    {
        get
        {
            return _sectionPrefab;
        }
        set
        {
            _sectionPrefab = value;
        }
    }

    [SerializeField]
    private Transform _bpmPrefab;
    /// <summary>
    /// The BPM prefab instantiated should there be any sections at all.
    /// </summary>
    public Transform BpmPrefab
    {
        get
        {
            return _bpmPrefab;
        }
        set
        {
            _bpmPrefab = value;
        }
    }

    //public GameObject ObjLane;
    public GameObject[] Cameras;
    // Use this for initialization
    bool bStarted = false;

    IEnumerator ReadPhase2()
	{
		
		string pathaux = Application.streamingAssetsPath + Path;
		string[] filedata = null;

		if (pathaux.Contains("://"))
		{
			WWW www = new WWW(pathaux);
			yield return www;
			//filedata = www.text;
			//filedata = www.text.Split('\n'); //C#


			filedata = www.text.Split(
				 new [] {  '\r' ,  '\n' } );

			//Debug.Log(pathaux + " " + www.text);
		}
		else
		{
			filedata = IO.ReadFile(pathaux);
		}


		ChartReader chartReader = new ChartReader();
		Chart = chartReader.ReadChartFileFromData(filedata);
		currentDifficulty = RetrieveDifficulty();
		SpawnNotes(Chart.GetNotes(currentDifficulty));
		SpawnStarPower(Chart.GetStarPower(currentDifficulty));
		notelist = Chart.GetNotes(currentDifficulty);

		//SpawnSections(Chart.Sections);
		SpawnSynchTracks(Chart.SynchTracks);
		StartSong();

	}



	void Start ()
    {
        bStarted = true;
        HidePreviewCameras();
        if(Modules.fLaneAngle > 0)
            Cameras[(int)(Modules.fLaneAngle - 1)].SetActive(true);
        else
            Cameras[0].SetActive(true);

        Init();
    }

    void Init()
    {
        regenerating = true;

        Globalvars.numberofnotes = 0;
        Globalvars.indexofnotes = 0;
        _speed = Globalvars.speed;
        _path = Globalvars.songpath;

        if(bStarted)
            StartCoroutine("ReadPhase2");
    }

    public void RestartChartLoader()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform obj = transform.GetChild(i);
            GameObject.Destroy(obj.gameObject);
        }

        Init();
    }

    void Update()
	{
		//Debug.Log("update" +Globalvars.numberofnotes + " " + regenerating);
		if ((Globalvars.numberofnotes < regeneratingsignal) && (!regenerating))
		{
			regenerating = true;
		//	Debug.Log("regenerating" + Globalvars.indexofnotes);
			SpawnNotesIndex(Globalvars.indexofnotes, notestogenerate);
		}
	}

	static void Update(ChartLoaderTest instance)
	{
		Debug.Log("update");
		if ((Globalvars.numberofnotes < regeneratingsignal) &&( !regenerating))
		{
			regenerating = true;
			Debug.Log("regenerating "+Globalvars.indexofnotes);
			instance.SpawnNotesIndex( Globalvars.indexofnotes, notestogenerate);
		}
	}

    void HidePreviewCameras()
    {
        foreach (GameObject cam in Cameras)
        {
            cam.SetActive(false);
        }
    }

    /// <summary>
    /// Retrieves the string enumerator version.
    /// </summary>
    /// <returns>string</returns>
    private string RetrieveDifficulty()
    {
        string result;
        switch (difficulty)
        {
            case Difficulty.EasyGuitar:
                result = "EasySingle";
                break;
            case Difficulty.MediumGuitar:
                result = "MediumSingle";
                break;
            case Difficulty.HardGuitar:
                result = "HardSingle";
                break;
            case Difficulty.ExpertGuitar:
                result = "ExpertSingle";
                break;
            case Difficulty.EasyDrums:
                result = "EasyDrums";
                break;
            case Difficulty.MediumDrums:
                result = "MediumDrums";
                break;
            case Difficulty.HardDrums:
                result = "HardDrums";
                break;
            case Difficulty.ExpertDrums:
                result = "ExpertDrums";
                break;
            default:
                result = "ExpertSingle";
                break;
        }

        return result;
    }

    /// <summary>
    /// Spawns all sections related to this chart.
    /// </summary>
    /// <param name="events">The events to be spawned.</param>
    private void SpawnSections(Section[] events)
    {
        Transform tmp;
        foreach (Section section in events)
        {
            tmp = SpawnPrefab(SectionPrefab, 
                transform, 
                new Vector3(-2.5f, 0, section.Seconds * Speed)
                );
            tmp.GetChild(0).GetComponent<TextMesh>().text = section.SectionName;
        }
    }

    /// <summary>
    /// Spawns a synch track.
    /// </summary>
    /// <param name="starPowers">The star power array.</param>
    private void SpawnSynchTracks(SynchTrack[] SynchTracks)
    {
        Transform tmp;
        foreach (SynchTrack synchTrack in SynchTracks)
        {
            tmp = SpawnPrefab(BpmPrefab, transform, new Vector3(3f, 0, synchTrack.Seconds * Speed));
            tmp.GetChild(0).GetComponent<TextMesh>().text = "BPM: " + (synchTrack.BeatsPerMinute / 1000) + " " + synchTrack.Measures + "/" + synchTrack.Measures;
        }
    }

    /// <summary>
    /// Spawns a star power background.
    /// </summary>
    /// <param name="starPowers">The star power array.</param>
    private void SpawnStarPower(StarPower[] starPowers)
    {
        Transform tmp;
        foreach (StarPower starPower in starPowers)
        {
            tmp = SpawnPrefab(StarPowerPrefab, transform, new Vector3(0, 0, starPower.Seconds * Speed));
            tmp.localScale = new Vector3(1, 1, starPower.DurationSeconds * Speed);
        }
    }

    /// <summary>
    /// Spawns all notes associated to the provided array.
    /// </summary>
    /// <param name="notes">Your array of notes.</param>
    private void SpawnNotes(Note[] notes)
    {

		if (!regenerating) return;
		regenerating = false;
		Debug.Log("SpawnNotes ");
		Debug.Log("NOTEs " + notes.Length);
		Globalvars.numbeofnotestotal = notes.Length;
		notelist = notes;
		Debug.Log("NOTELIST " + notelist.Length);
		GameObject.Find("Notelist").GetComponent<Notelist>().listofnotes = notelist;

		int maxnum = 0;
		int limit = notestogenerate;
        Transform noteTmp;
        float z;

        foreach (Note note in notes)
        {
			Globalvars.numberofnotes = Globalvars.numberofnotes + 1;
			maxnum = maxnum + 1;
			Globalvars.indexofnotes = maxnum;
			if(maxnum > limit)
				return;
			

            z = note.Seconds * Speed;
            for (int i = 0; i < 5; i++)
            {
                if (note.ButtonIndexes[i])
                {
                    noteTmp = SpawnPrefab(SolidNotes[i], transform, new Vector3(i - 2f, 0, z));
                    noteTmp.transform.localScale = new Vector3(Modules.fNoteSize, Modules.fNoteSize, Modules.fNoteSize);
                    SetLongNoteScale(noteTmp.GetChild(0), note.DurationSeconds * Speed);
                    if (note.IsHOPO)
                        SetHOPO(noteTmp);
                    else
                        SetHammerOnColor(noteTmp, (note.IsHammerOn && !note.IsChord && !note.ForcedSolid));
                }
            }
        }
    }

	private void SpawnNotesIndex( int index, int size)
	{
		if (!regenerating) return;

		int length = GameObject.Find("Notelist").GetComponent<Notelist>().listofnotes.Length;
		Note[] notes = new Note[length];


		for (int a = 0; a < length; a++)
		{
		//	Debug.Log(a);
			notes [a] = (Note) GameObject.Find("Notelist").GetComponent<Notelist>().listofnotes[a] as Note;
		}

		//Debug.Log("index " + index + "list" + notes.Length);
		int maxnum = 0;
		int limit = size;
		Transform noteTmp;
		float z;

		for (int j = index; j < notes.Length;  j++)
		{
			Note note = notes[j];
			Globalvars.numberofnotes = Globalvars.numberofnotes + 1;
			Globalvars.indexofnotes = j;
			maxnum = maxnum + 1;

			if (maxnum >= limit)
			{
				regenerating = false;
				return;
			}

			z = note.Seconds * Speed;

			for (int i = 0; i < 5; i++)
			{
				if (note.ButtonIndexes[i])
				{
					noteTmp = SpawnPrefab(SolidNotes[i], transform, new Vector3(i - 2f, 0, z));
					SetLongNoteScale(noteTmp.GetChild(0), note.DurationSeconds * Speed);
					if (note.IsHOPO)
						SetHOPO(noteTmp);
					else
						SetHammerOnColor(noteTmp, (note.IsHammerOn && !note.IsChord && !note.ForcedSolid));
				}
			}


		}
		regenerating = false;

	}
	
    /// <summary>
    /// Starts playing the song.
    /// </summary>
    private void StartSong()
    {
		//GameObject.Find("VideoPlayer").GetComponent<HighQualityPlayback>().PlayYoutubeVideo(GameObject.Find("VideoPlayer").GetComponent<HighQualityPlayback>().videoId);
        CameraMovement.Speed = Speed;
        CameraMovement.enabled = true;
        PlayMusic();
    }

    /// <summary>
    /// Plays the current song.
    /// </summary>
    private void PlayMusic()
    {
        //Music.Play();
    }

    /// <summary>
    /// Spawns a prefab in world space.
    /// </summary>
    /// <param name="prefab">The prefab you would like to instantiate.</param>
    /// <param name="parent">The parent of the prefab.</param>
    /// <param name="position">The world position of the prefab.</param>
    /// <returns>Transform</returns>
    private Transform SpawnPrefab(Transform prefab, 
        Transform parent, 
        Vector3 position)
    {
        Transform tmp;

        tmp = Instantiate(prefab);
        tmp.SetParent(parent);
        tmp.localPosition = position;
        tmp.name = prefab.name;
        return tmp;
    }

    /// <summary>
    /// Sets the length of the long note.
    /// </summary>
    /// <param name="note">The long note to be modified.</param>
    /// <param name="length">The length of the long note.</param>
    private void SetLongNoteScale(Transform note, float length)
    {
		if (length > 0)
			note.parent.gameObject.GetComponent<NoteLongControl>().islong = true;
        note.localScale = new Vector3(note.localScale.x, note.localScale.y,  length);
    }

    /// <summary>
    /// Sets the note color brighter if it is a hammer on.
    /// </summary>
    /// <param name="note">The note you would like to edit.</param>
    /// <param name="isHammerOn">Is the current note a hammer on?</param>
    private void SetHammerOnColor(Transform note, bool isHammerOn)
    {
        SpriteRenderer re;
        Color color;
        if (isHammerOn)
        {
            re = note.GetComponent<SpriteRenderer>();
            color = re.color;
            re.color = new Color(color.r + 0.75f, color.g + 0.75f, color.b + 0.75f);
        }
    }

    /// <summary>
    /// Sets the note to be HOPO note.
    /// </summary>
    /// <param name="note">The note you would like to edit.</param>
    private void SetHOPO(Transform note)
    {
        SpriteRenderer re;
        Color color;
        re = note.GetComponent<SpriteRenderer>();
        color = re.color;
        re.color = new Color(0.75f, 0, 0.75f);

    }
}
