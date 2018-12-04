    class Destination : IComparable<Destination>{
        public int totalPrice;
        public int index;
        public int stopNo;
        
        public Destination(int totalPrice, int index, int stopNo){
            this.totalPrice = totalPrice;
            this.index = index;
            this.stopNo = stopNo;
        }

        public int CompareTo(Destination other){
            int result = this.totalPrice.CompareTo(other.totalPrice);
            return result == 0 ? this.index.CompareTo(other.index) : result;
        }
    }  
    
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        
        int[,] graph = new int[n,n];      
        bool[] visited = new bool[n];
        int[] minPrices = new int[n];    
        GenericMinHeap<Destination> minHeap = new  GenericMinHeap<Destination>(n * n);
        
        for (int i = 0; i < flights.GetLength(0); i++){           
            int s = flights[i][0];
            int d = flights[i][1];
            int p = flights[i][2];           
            graph[s,d] = p;
        }

        for (int i = 0; i < n; i++){
            minPrices[i] = int.MaxValue;
        }
        minPrices[src] = 0;
        
        minHeap.Add(new Destination(0, src, 0));
        while (minHeap.Size > 0){
            Destination next = minHeap.Poll();
            int index = next.index;
            int price = next.totalPrice;
            int stopNo = next.stopNo;
            visited[index] = true;
            if (stopNo <= k){
                for (int i = 0; i < n; i++){
                    if (graph[index,i] > 0 && !visited[i]){
                        int totalPrice = price + graph[index,i];
                        minHeap.Add(new Destination(totalPrice , i, stopNo + 1));
                        minPrices[i] = Math.Min(minPrices[i], totalPrice);
                    }
                }
            }
        }
        return minPrices[dst] == int.MaxValue ? -1 : minPrices[dst];
    }
