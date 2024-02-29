using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuCam;
    public GameObject gameCam;
    public Player player;
    public Boss boss;
    public int stage;
    public float playTime;
    public bool isBattle;
    public int enemyCntA;
    public int enemyCntB;
    public int enemyCntC;

    public GameObject menuPanel;
    public GameObject gamePanel;
    public TMP_Text maxScoreTxt;
    public TMP_Text scoreTxt;
    public TMP_Text stageTxt;
    public TMP_Text playTimeTxt;
    public TMP_Text playerHealthTxt;
    public TMP_Text playerAmmoTxt;
    public TMP_Text playerCoinTxt;
    public Image weapon1Img;
    public Image weapon2Img;
    public Image weapon3Img;
    public Image weaponRImg;
    public TMP_Text enemyATxt;
    public TMP_Text enemyBTxt;
    public TMP_Text enemyCTxt;
    public RectTransform bossHealthGroup;
    public RectTransform bossHealthBar;

    void Awake()
    {
        maxScoreTxt.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));
    }

    public void GameStart()
    {
        menuCam.SetActive(false);
        gameCam.SetActive(true);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);

        player.gameObject.SetActive(true);
    }

    void Update()
    {
        if (isBattle)
            playTime += Time.deltaTime;
    }

    void LateUpdate()
    {
        // 상단 UI
        scoreTxt.text = string.Format("{0:n0}", player.score);
        stageTxt.text = "STAGE " + stage;

        int hour = (int)(playTime / 3600);
        int min = (int)((playTime - hour * 3600) / 60);
        int second = (int)(playTime % 60);
        playTimeTxt.text = string.Format("{0:00}", hour) + ":" + string.Format("{0:00}", min) + ":"
                           + string.Format("{0:00}", second);

        // 플레이어 UI
        playerHealthTxt.text = player.health + " / " + player.maxHealth;
        playerCoinTxt.text = string.Format("{0:n0}", player.coin);
        if (player.equipWeapon == null) {
            playerAmmoTxt.text = "- / " + player.ammo;
        } else if (player.equipWeapon.type == Weapon.Type.Melee) {
            playerAmmoTxt.text = "- / " + player.ammo;
        } else {
            playerAmmoTxt.text = player.equipWeapon.curAmmo + " / " + player.ammo;
        }

        // 무기 UI
        weapon1Img.color = new Color(1, 1, 1, player.hasWeapons[0] ? 1 : 0);
        weapon2Img.color = new Color(1, 1, 1, player.hasWeapons[1] ? 1 : 0);
        weapon3Img.color = new Color(1, 1, 1, player.hasWeapons[2] ? 1 : 0);
        weaponRImg.color = new Color(1, 1, 1, player.hasGrenades > 0 ? 1 : 0);

        // 몬스터 숫자 UI
        enemyATxt.text = "x " + enemyCntA;
        enemyBTxt.text = "x " + enemyCntB;
        enemyCTxt.text = "x " + enemyCntC;

        // 보스 UI
        bossHealthBar.localScale = new Vector3((float)boss.curHealth / boss.maxHealth, 1, 1);
    }
}
