using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Enemies
{
    public interface IEnemyState
    {
        public void MoveLeft();
        public void MoveRight();
        public void Kill();
        public void FallingKill();
        public void Update();
    }
}
