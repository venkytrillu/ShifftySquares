using Entitas;
using UnityEngine;

namespace Interfaces.View
{
    public interface IViewController
    {
        Vector3 Position {get; set;}
        Vector3 Scale {get; set;}
        bool isActive {get; set;}
        GameObject ClonedGameObject{get;}
        void InitializeView(Contexts contexts, IEntity Entity,GameObject obj);
        void DestroyView();
    }
}