using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerSO : MonoBehaviour
{
  #region Singelton

  public static PlayerManagerSO instance;

  private void Awake()
  {
    instance = this;
  }

  #endregion

  public GameObject player;

}
