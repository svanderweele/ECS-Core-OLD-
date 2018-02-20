using Entitas;


using UnityEngine;

namespace Libraries.btcp.ECS.src.Core.Input.Logic
{
    public class EmitInputSystem : IInitializeSystem, IExecuteSystem, ICleanupSystem
    {
        private readonly InputContext m_contexts;
        private InputEntity m_leftMouseEntity;
        private InputEntity m_rightMouseEntity;

        public EmitInputSystem(Contexts contexts)
        {
            m_contexts = contexts.input;
        }

        public void Execute()
        {
            
            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            if (UnityEngine.Input.GetMouseButtonDown(0)) m_leftMouseEntity.ReplaceMouseDown(mousePosition);
            if (UnityEngine.Input.GetMouseButtonUp(0)) m_leftMouseEntity.ReplaceMouseUp(mousePosition);

            m_leftMouseEntity.ReplaceMousePosition(mousePosition);

            if (UnityEngine.Input.GetMouseButtonDown(1)) m_rightMouseEntity.ReplaceMouseDown(mousePosition);
            if (UnityEngine.Input.GetMouseButtonUp(1)) m_rightMouseEntity.ReplaceMouseUp(mousePosition);
            
            m_rightMouseEntity.ReplaceMousePosition(mousePosition);

        }

        public void Initialize()
        {
            m_contexts.isLeftMouse = true;
            m_leftMouseEntity = m_contexts.leftMouseEntity;

            m_contexts.isRightMouse = true;
            m_rightMouseEntity = m_contexts.rightMouseEntity;
        }

        public void Cleanup()
        {
            if(m_leftMouseEntity.hasMouseDown)  m_leftMouseEntity.RemoveMouseDown();
            if(m_leftMouseEntity.hasMouseUp)  m_leftMouseEntity.RemoveMouseUp();
            if(m_leftMouseEntity.hasMousePosition)  m_leftMouseEntity.RemoveMousePosition();
            if(m_rightMouseEntity.hasMouseDown)  m_rightMouseEntity.RemoveMouseDown();
            if(m_rightMouseEntity.hasMouseUp)  m_rightMouseEntity.RemoveMouseUp();
            if(m_rightMouseEntity.hasMousePosition)  m_rightMouseEntity.RemoveMousePosition();

        }
    }
}