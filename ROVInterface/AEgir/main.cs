using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEgir {
    public static class main {

        private static int i = 0;

        public static int returnint() {
            return ++i;
        }

        /*
            Need two functions
            byte[] ConvertCommands(int index, int value);
            Pair<int,int> ConvertData(byte[] b);
        */

        public static byte[] ConvertCommands(int index, int value) {

			return null;
            /*byte[] packet = new byte[6];

            packet[0] = (byte)(index >> 8);
            packet[1] = (byte)(index >> 0);
            
            packet[5] = (byte)(value >> 24);
            packet[4] = (byte)(value >> 16);
            packet[3] = (byte)(value >> 8);
            packet[2] = (byte)(value >> 0);

            return packet;*/
        }

        public static KeyValuePair<int, int> ConvertData(byte[] b) {

            return new KeyValuePair<int,int>(0, -1);
        }
    }
}