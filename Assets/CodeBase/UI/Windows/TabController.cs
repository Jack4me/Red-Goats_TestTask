using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.Windows
{
    public class TabController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> tabs;

        private void Start()
        {
            OpenTab(0);
        }

        public void OpenTab(int tabIndex)
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                tabs[i].SetActive(i == tabIndex);
            }
        }
    }
}