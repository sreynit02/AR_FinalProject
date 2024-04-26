using UnityEngine;
using Microsoft.MixedReality.OpenXR;
using TMPro;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.XR.ARSubsystems;


public class TestQRCodeDetection : MonoBehaviour
{
    [SerializeField] private GameObject mainText;
    [SerializeField] private ARMarkerManager markerManager;

    private TextMeshProUGUI m_TextMeshPro;
    //private HashSet<Guid> recordedIds = new HashSet<Guid>(); // HashSet to store recorded IDs
    private List<string> recordedNames = new List<string>();
    private DateTime gameStartTime;
    private void Start()
    {
        gameStartTime = DateTime.Now;
        if (markerManager == null)
        {
            Debug.LogError("ARMarkerManager is not assigned.");
            return;
        }

        // Subscribe to the markersChanged event
        markerManager.markersChanged += OnMarkersChanged;

        // Initialize TextMeshPro
        m_TextMeshPro = (mainText != null) ? mainText.GetComponent<TextMeshProUGUI>() : null;
        if (m_TextMeshPro == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on mainText GameObject.");
        }

    }

    /// <summary>
    /// Handles the markersChanged event and processes added, updated, and removed markers.
    /// </summary>
    /// <param name="args">Event arguments containing information about added, updated, and removed markers.</param>
    private void OnMarkersChanged(ARMarkersChangedEventArgs args)
    {
        foreach (var addedMarker in args.added)
        {
            HandleAddedMarker(addedMarker);
        }

        foreach (var updatedMarker in args.updated)
        {
            HandleUpdatedMarker(updatedMarker);
        }

        foreach (var removedMarkerId in args.removed)
        {
            HandleRemovedMarker(removedMarkerId);
        }
    }

    /// <summary>
    /// Handles logic for newly added markers.
    /// </summary>
    /// <param name="addedMarker">The newly added ARMarker.</param>
    private void HandleAddedMarker(ARMarker addedMarker)
    {
        Debug.Log($"QR Code Detected! Marker ID: {addedMarker.trackableId}");
        string qrCodeString = addedMarker.GetDecodedString();

        //if (m_TextMeshPro != null)
        //{
        //    m_TextMeshPro.text = qrCodeString;
        //}

        if (!recordedNames.Contains(qrCodeString))
        {
            // Get the decoded string from the updated marker


            // Record the time when the QR code is scanned
            DateTime currentTime = DateTime.Now;
            string scanTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

            // Calculate the time elapsed since the game started
            TimeSpan elapsedTime = DateTime.Now - gameStartTime;
            string elapsedTimeFormatted = string.Format("{0}:{1:D2}:{2:D2}",
                elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds);


            // Set the QR code string to the TextMeshPro component

            // Record the QR code information and scan time in the data file
            //RecordData($"QR Code Detected -QRCodeName:{qrCodeString}, ID: {updatedMarker.trackableId}, Time: {scanTime}, TimeElapsed: {elapsedTimeFormatted}");
            RecordData($"QRCodeName:{qrCodeString}, Time: {scanTime}, TimeElapsed: {elapsedTimeFormatted}");
            //Add the ID 
            //recordedIds.Add(updatedMarker.trackableId.ToGuid());
            recordedNames.Add(qrCodeString);
        }

        // You can access more information about the marker using addedMarker properties
        // For example, addedMarker.GetDecodedString() or addedMarker.GetQRCodeProperties()
        // Additional handling logic for newly added markers

    }

    /// <summary>
    /// Handles logic for updated markers.
    /// </summary>
    /// <param name="updatedMarker">The updated ARMarker.</param>
    private void HandleUpdatedMarker(ARMarker updatedMarker)
    {
        string qrCodeString = updatedMarker.GetDecodedString();
        //if (!recordedIds.Contains(updatedMarker.trackableId.ToGuid()))

        if (m_TextMeshPro != null)
        {
            m_TextMeshPro.text = qrCodeString;
        }
        
        
    }

    /// <summary>
    /// Handles logic for removed markers.
    /// </summary>
    /// <param name="removedMarkerId">The ID of the removed marker.</param>
    private void HandleRemovedMarker(ARMarker removedMarkerId)
    {
        Debug.Log($"QR Code Removed! Marker ID: {removedMarkerId}");

        // Clear the TextMeshPro text when a marker is removed
        if (m_TextMeshPro != null)
        {
            m_TextMeshPro.text = string.Empty;
        }
    }

    /// <summary>
    /// Records data to the text file.
    /// </summary>
    /// <param name="data">Data string to record.</param>
    private void RecordData(string data)
    {
        string filename = "Data.txt";
        string path = System.IO.Path.Combine(Application.persistentDataPath, filename);
        path = path.Replace("/", @"\");

        // Append data to the file
        
        using (StreamWriter writer = new StreamWriter(path, true))
        {

            writer.WriteLine(data);
        }
    }

}