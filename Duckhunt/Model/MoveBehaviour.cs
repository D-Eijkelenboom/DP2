using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duckhunt.Model
{
    abstract class MoveBehaviour
    {
        public MoveBehaviour() { }
        public MoveBehaviour(Unit unit) { }

        public abstract void Move();

        public virtual Unit Unit { get; set; }
    }
}
