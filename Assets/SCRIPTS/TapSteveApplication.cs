using UnityEngine;
using System.Collections;


// Base class for all elements in this application.
public class TapSteveElement : MonoBehaviour
{
   // Gives access to the application and all instances.
   public TapSteveApplication app { get { return GameObject.FindObjectOfType<TapSteveApplication>(); }}
}

// 10 Bounces Entry Point.
public class TapSteveApplication : MonoBehaviour
{
   // Reference to the root instances of the MVC.
   public MainModel model;
   public MainView view;
   public MainController controller;

   //components
   public PunchComponent punchcomponent;
   public ProgressBarComponent progressbarcomponent;

}