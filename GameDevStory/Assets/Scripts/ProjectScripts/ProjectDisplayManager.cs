﻿using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Handles the Project UI
namespace ProjectScripts
{
    public class ProjectDisplayManager : MonoBehaviour
    {
        public GameObject ProjectSelectionContent;
        public GameObject ProjectEntryPrefab;
        public GameObject ProjectTitlePrefab;

        public GameObject ProjectCompletePanel;
        public GameObject ProjectCompleteContent;
        public GameObject Star;
        public GameObject HollowStar;
        public Text ProfitText;
        public Text FeedbackText;
        public Text BugStatsText;

        public GameObject DescriptionPanel;
        public Text DescriptionTitle;
        public Text DescriptionCompany;
        public Text DescriptionContent;
        public Text DescriptionStats;
    
        protected ProjectDisplayManager () {} // enforces singleton use

        // Removes all projects from the project container
        public void ClearAllProjects()
        {
            foreach (Transform child in ProjectSelectionContent.transform) {
                GameObject.Destroy(child.gameObject);
            }
            Instantiate(ProjectTitlePrefab, Vector3.zero, Quaternion.identity, ProjectSelectionContent.transform);
        }

        // Adds a project to the project menu
        public void AddNewProject(string title, string company, string description, string stats, bool selectable, 
            Action<string> callback)
        {
            var projectPrefab = Instantiate(ProjectEntryPrefab, Vector3.zero, Quaternion.identity, ProjectSelectionContent.transform);
            var text = projectPrefab.GetComponentsInChildren<Text>();
            text[0].text = title;
            text[1].text = company;
            text[2].text = description;
            text[3].text = stats;
        
            var button = projectPrefab.GetComponentsInChildren<Button>(true); // get inactive children too!
            if (selectable)
            {
                button[0].onClick.AddListener(delegate { callback(title); }); // set button callback
            }
            else
            {
                button[0].interactable = false;
            }
        }

        public void ProjectDescription(string title, string company, string description, string stats)
        {
            DescriptionPanel.SetActive(true);
            DescriptionTitle.text = title;
            DescriptionCompany.text = company;
            DescriptionContent.text = description;
            DescriptionStats.text = stats;
        }

        public void CloseProjectDescription()
        {
            DescriptionPanel.SetActive(false);
        }

        // overload for unselectable
        public void AddNewProject(string title, string company, string description, string stats, bool selectable)
        {
            AddNewProject(title, company, description, stats, selectable, delegate {  });
        }

        // Displays the project completion display
        public void ProjectCompleted(double profit, string feedback)
        {
            // todo: add diversity score in feedback
            ProjectCompletePanel.SetActive(true);
            ProfitText.text = "$" + profit.ToString("f2");

            FeedbackText.text = feedback;
        }

        // Closes the project completion display
        public void CloseProjectCompleted()
        {
            ProjectCompletePanel.SetActive(false);
            /*foreach (Transform child in ProjectCompleteContent.transform) {
                GameObject.Destroy(child.gameObject);
            }*/
        }
    
    }
}
