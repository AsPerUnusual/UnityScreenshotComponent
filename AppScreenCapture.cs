using System; //for DateTime
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//important basics adapted from https://gamedevbeginner.com/how-to-capture-the-screen-in-unity-3-methods/


public class AppScreenCapture : MonoBehaviour
{
    
    [SerializeField, Tooltip( "use this key for regular screenshots" )]
    private KeyCode _screenShotKey;
    
    [SerializeField, Tooltip( "use this key for higher res screenshots" )]
    private KeyCode _highResScreenShotKey;
    
    [SerializeField, Tooltip( "high res factor: 2 for 2x, watch artifacting" )]
    private int _highResAmount = 2; // see link above for details, but higher resolution may have artifacts/sampling differences in some cases
    
    [SerializeField, Tooltip( "main base for filename" )]
    private String _baseFilenameText = "projectName";
    
    private String _filesystemSafeDate = "yyyy-MM-dd(HH-mm-ss)";
    
    void Start()
    {
    	//Debug.Log( System.DateTime.Now.ToString( "yyyy-MM-dd(HH-mm-ss)" ) );
    }

    void Update()
    {
        if ( Input.GetKeyDown( _screenShotKey ) ) {
    	
    			StartCoroutine( TakeTheShot() );
    	}
    	
    	if ( Input.GetKeyDown( _highResScreenShotKey ) ) {
    	
    			StartCoroutine( TakeTheHighResShot() );
    	}
    }
    
    private IEnumerator TakeTheShot() {
    
    	yield return new WaitForEndOfFrame();
    	
    	string getFormattedTime = System.DateTime.Now.ToString( _filesystemSafeDate );

    	ScreenCapture.CaptureScreenshot( _baseFilenameText + "_" + getFormattedTime + ".png");
    }
    
    private IEnumerator TakeTheHighResShot() {
    
    	yield return new WaitForEndOfFrame();
    	
    	string getFormattedTime = System.DateTime.Now.ToString( _filesystemSafeDate );

    	ScreenCapture.CaptureScreenshot( _baseFilenameText + "_" + _highResAmount + "x_" + getFormattedTime + ".png", _highResAmount );
    }
    
    public void TakeScreenShotWithCode() {  // use with gameplay code or button, hiding the UI takes a separate camera that doesn't render the UI, check linked article at the top of this file.
    
    	StartCoroutine( TakeTheShot() );
    }
    
}
