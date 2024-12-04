using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCVProyecto2P2.Utilidades
{
    public class MensajeriaP : ValueChangedMessage<CuerpoP>
    {
        public MensajeriaP(CuerpoP value) : base(value) { }
    }
}
