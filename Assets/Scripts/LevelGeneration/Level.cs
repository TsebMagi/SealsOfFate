using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LevelGeneration {
    internal class Level : Feature {
        public int[,] MiniMap;

        /// <summary> Generates a level </summary>
        public void Generate(int minChunks, int maxChunks, int chunkDimension) {
            // setup the graph
            var numRooms = Random.Range(minChunks, maxChunks);
            // size the map to allow for each room take up the maximum and leave space for tunnels
            XRange.max = YRange.max = chunkDimension * numRooms + 2;
            XRange.min = YRange.min = 0;
            FeatureMap = new int[XRange.max, YRange.max];
            BuildMiniMap(numRooms);
            BuildChunks(chunkDimension);
            FillInWalls();
        }

        /// <summary>
        /// Builds out a random miniMap of the level with the given number of chunks.
        /// </summary>
        /// <param name="numChunks">The number of chunks to place during build</param>
        private void BuildMiniMap(int numChunks) {
            // Potential spots to place new chunks at.
            var potentialSlots = new List<Vector2>();
            // make the miniMap large enough
            MiniMap = new int[numChunks, numChunks];
            // make the centerpoint the first chunk to be placed
            potentialSlots.Add(new Vector2(numChunks / 2, numChunks / 2));
            // place chunks until there are none left to place
            for (var i = 0; i < numChunks; ++i) {
                // grab a random chunk from the list of potential slots
                var toPlace = potentialSlots[Random.Range(0, potentialSlots.Count)];
                // remove the chosen chunk from the future options
                potentialSlots.Remove(toPlace);
                var numToRemove = potentialSlots.Count / 2;
                for (var j = 0; j < numToRemove - 1; ++j) {
                    var toRemove = potentialSlots[Random.Range(0, potentialSlots.Count)];
                    potentialSlots.Remove(toRemove);
                }
                MiniMap[(int) toPlace.x, (int) toPlace.y] = 1;
                if (toPlace.x < MiniMap.GetLength(0) - 1 && MiniMap[(int) toPlace.x + 1, (int) toPlace.y] != 1 &&
                    potentialSlots.Contains(new Vector2(toPlace.x + 1, toPlace.y)) != true) {
                    potentialSlots.Add(new Vector2(toPlace.x + 1, toPlace.y));
                }
                if (toPlace.x > 0 && MiniMap[(int) toPlace.x - 1, (int) toPlace.y] != 1 &&
                    potentialSlots.Contains(new Vector2(toPlace.x - 1, toPlace.y)) != true) {
                    potentialSlots.Add(new Vector2(toPlace.x - 1, toPlace.y));
                }
                if (toPlace.y < MiniMap.GetLength(0) - 1 && MiniMap[(int) toPlace.x, (int) toPlace.y + 1] != 1 &&
                    potentialSlots.Contains(new Vector2(toPlace.x, toPlace.y + 1)) != true) {
                    potentialSlots.Add(new Vector2(toPlace.x, toPlace.y + 1));
                }
                if (toPlace.y > 0 && MiniMap[(int) toPlace.x, (int) toPlace.y - 1] != 1 &&
                    potentialSlots.Contains(new Vector2(toPlace.x, toPlace.y - 1)) != true) {
                    potentialSlots.Add(new Vector2(toPlace.x, toPlace.y - 1));
                }
            }
        }

        private void BuildChunks(int chunkDimension) {
            for (var x = 1; x < MiniMap.GetLength(0) - 1; ++x) {
                for (var y = 1; y < MiniMap.GetLength(1) - 1; ++y) {
                    if (MiniMap[x, y] == 1) {
                        for (var j = 0; j < chunkDimension; ++j) {
                            for (var k = 0; k < chunkDimension; ++k) {
                                FeatureMap[x * chunkDimension + j, y * chunkDimension + k] =
                                    (int) LevelDecoration.Floor;
                            }
                        }
                    }
                }
            }
        }

        private void FillInWalls() {
            for (var x = 0; x < FeatureMap.GetLength(0); x++) {
                for (var y = 0; y < FeatureMap.GetLength(1); y++) {
                    if (FeatureMap[x, y] == 0 && CheckAdjacent(x, y) > 0) {
                        FeatureMap[x, y] = (int) LevelDecoration.Wall;
                    }
                }
            }
        }
    }
}