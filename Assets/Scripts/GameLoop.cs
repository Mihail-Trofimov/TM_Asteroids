using System.Collections.Generic;

namespace Asteroids
{
    public class GameLoop: IExecute, IFixExecute
    {
        private List<IExecute> _executes = new List<IExecute>();
        private List<IFixExecute> _fixExecutes = new List<IFixExecute>();

        public void Execute()
        {
            for (int i = 0; i < _executes.Count; i++)
            {
                    _executes[i].Execute();
            }
        }

        public void FixExecute()
        {
            for (int i = 0; i < _fixExecutes.Count; i++)
            {
                _fixExecutes[i].FixExecute();
            }
        }

        public void AddExecute(IExecute execute)
        {
            if(!_executes.Contains(execute)) _executes.Add(execute);
        }

        public void AddFixExecute(IFixExecute fixExecute)
        {
            if (!_fixExecutes.Contains(fixExecute)) _fixExecutes.Add(fixExecute);
        }

        public void RemoveExecute(IExecute execute)
        {
            if (_executes.Contains(execute)) _executes.Remove(execute);
        }

        public void RemoveFixExecute(IFixExecute fixExecute)
        {
            if (_fixExecutes.Contains(fixExecute)) _fixExecutes.Remove(fixExecute);
        }

    }
}