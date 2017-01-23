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
            public static byte[] ConvertCommands(KeyValuePair<int, int>[]);
            public static Pair<int,int>[] ConvertData(byte[]);
        */

        public static byte[] ConvertCommands(KeyValuePair<int, int>[] data) {
            
            
            byte[] packet = new byte[6];

            /*packet[0] = (byte)(index >> 8);
            packet[1] = (byte)(index >> 0);
            
            packet[5] = (byte)(value >> 24);
            packet[4] = (byte)(value >> 16);
            packet[3] = (byte)(value >> 8);
            packet[2] = (byte)(value >> 0);*/

            return packet;
        }

        public static KeyValuePair<int, int>[] ConvertData(byte[] b) {
			return null;
        }
    }
}