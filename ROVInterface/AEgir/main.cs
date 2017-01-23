using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEgir {
    public static class main {

        /*
            Need two functions
            public static byte[] ConvertCommands(KeyValuePair<int, int>[]);
            public static Pair<int,int>[] ConvertData(byte[]);
        */

        public static byte[] ConvertCommands(KeyValuePair<int, int>[] commands) {

			byte[] packet = new byte[commands.Length * 6];
			for (int i = 0, j = commands.Length, cur; i < j; i++) {
				cur = i * 6;
				packet[cur + 0] = (byte)(commands[i + 0].Key >> 8);
				packet[cur + 1] = (byte)(commands[i + 1].Key >> 0);

				packet[cur + 5] = (byte)(commands[i + 2].Value >> 24);
				packet[cur + 4] = (byte)(commands[i + 3].Value >> 16);
				packet[cur + 3] = (byte)(commands[i + 4].Value >> 8);
				packet[cur + 2] = (byte)(commands[i + 5].Value >> 0);
			}

			return packet;
		}

        public static KeyValuePair<int, int>[] ConvertData(byte[] b) {
			return null;
        }
    }
}