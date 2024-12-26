using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public class TabButton : MonoBehaviour
    {
        [SerializeField] private int tabIndex;
        [SerializeField] private TabController tabController;

        private void Start() {
            GetComponent<Button>().onClick.AddListener(() => tabController.OpenTab(tabIndex));
        }
    }
}
