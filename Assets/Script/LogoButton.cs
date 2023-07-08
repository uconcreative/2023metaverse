using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using SimpleFileBrowser;

public class LogoButton : MonoBehaviour
{
    public GameObject logoObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickLogoButton()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"), new FileBrowser.Filter("Text Files", ".txt", ".pdf"));

        // Set default filter that is selected when the dialog is shown (optional)
        // Returns true if the default filter is set successfully
        // In this case, set Images filter as the default filter
        FileBrowser.SetDefaultFilter(".jpg");

        // Set excluded file extensions (optional) (by default, .lnk and .tmp extensions are excluded)
        // Note that when you use this function, .lnk and .tmp extensions will no longer be
        // excluded unless you explicitly add them as parameters to the function
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");

        // Add a new quick link to the browser (optional) (returns true if quick link is added successfully)
        // It is sufficient to add a quick link just once
        // Name: Users
        // Path: C:\Users
        // Icon: default (folder icon)
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);

        // Show a save file dialog 
        // onSuccess event: not registered (which means this dialog is pretty useless)
        // onCancel event: not registered
        // Save file/folder: file, Initial path: "C:\", Title: "Save As", submit button text: "Save"
        // FileBrowser.ShowSaveDialog( null, null, false, "C:\\", "Save As", "Save" );

        // Show a select folder dialog 
        // onSuccess event: print the selected folder's path
        // onCancel event: print "Canceled"
        // Load file/folder: folder, Initial path: default (Documents), Title: "Select Folder", submit button text: "Select"
        // FileBrowser.ShowLoadDialog( (path) => { Debug.Log( "Selected: " + path ); }, 
        //                                () => { Debug.Log( "Canceled" ); }, 
        //                                true, null, "Select Folder", "Select" );

        // Coroutine example
        StartCoroutine(ShowLoadDialogCoroutine());


        //Renderer renderer = logoObject.GetComponent<Renderer>();
        //if(null != renderer)
        //{
        //    string[] path = FileBrowser.ShowLoadDialog()
        //    //string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        //    if (path.Length != 0)
        //    {
        //        string filePath = path[0];
        //        var fileContent = File.ReadAllBytes(filePath);
        //        Texture2D tex2d = new Texture2D(2, 2);
        //        tex2d.LoadImage(fileContent); //..this will auto-resize the texture dimensions.
        //        renderer.material.mainTexture = tex2d;
        //    }
        //}
            
    }
    IEnumerator ShowLoadDialogCoroutine()
    {
        // Show a load file dialog and wait for a response from user
        // Load file/folder: file, Initial path: default (Documents), Title: "Load File", submit button text: "Load"
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, "Load File", "Load");

        // Dialog is closed
        // Print whether a file is chosen (FileBrowser.Success)
        // and the path to the selected file (FileBrowser.Result) (null, if FileBrowser.Success is false)
        Debug.Log(FileBrowser.Success + " " + FileBrowser.Result);

        if (FileBrowser.Success)
        {
            // If a file was chosen, read its bytes via FileBrowserHelpers
            // Contrary to File.ReadAllBytes, this function works on Android 10+, as well
            Renderer renderer = logoObject.GetComponent<Renderer>();
            if (null != renderer)
            {
                byte[] fileContent = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result);
                Texture2D tex2d = new Texture2D(2, 2);
                tex2d.LoadImage(fileContent); //..this will auto-resize the texture dimensions.
                renderer.material.mainTexture = tex2d;
            }
             
        }
    }

    public void HideLogo()
    {
        Renderer renderer = logoObject.GetComponent<Renderer>();
        if (null != renderer)
        {
            Texture2D tex = new Texture2D(2, 2, TextureFormat.ARGB32, false);

            Color fillColor = Color.clear;
            Color[] fillPixels = new Color[tex.width * tex.height];

            for (int i = 0; i < fillPixels.Length; i++)
            {
                fillPixels[i] = fillColor;
            }

            tex.SetPixels(fillPixels);
            tex.Apply();
            renderer.material.mainTexture = tex;
        }

        
    }
}
