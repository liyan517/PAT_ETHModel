using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PAT.Common.Classes.Expressions.ExpressionClass;


//the namespace must be PAT.Lib, the class and method names can be arbitrary
namespace PAT.Lib
{
	public class Batch : ExpressionValue
    {
        private int batchID;
        public bool isValid;
    	public int fridgeID;
    	public List<int[]> vials = new List<int[]>(3);
    	public DateTime expiryDate;
    	public IList<Vial> batch;
    	public Batch() {batch = new List<Vial>();}
    	public Batch(int batchID, bool isValid, int fridgeID, DateTime expiryDate){
    		batchID = batchID;
    		isValid = isValid;
    		fridgeID = fridgeID;
    		expiryDate = expiryDate;
    	}
    	
/*        public Batch(Batch batch):this(batch.batchID, batch.isValid, batch.fridgeID,batch.expiryDate){
       } */
    	
        public void addVial(Vial vial){
            batch.Add(vial);
        }


       public void addBatch(int batchID, DateTime expiryDate){
        	if(vials == null) 
        	{
        	  vials = new List<int[]>(3);
        	  
        	}
        	vials.Add(new int[] {vialid, vote});
        	
        }
        public int countVote() {
        	int count = 0;
        	foreach(int[] vial in vials){
        		count += vial[1];
        	}
        	return count;
        }
        
        public void SetBlockID(int id) {batchID = id;}
        public void SetMinerID(int id) { fridgeID = id;}
        public void SetValid(bool valid) {isValid = valid;}
        public bool IsValid() {return isValid;}
        public int GetMiner() {return fridgeID;}
        public int GetBlockID() {return batchID;}

        /// <summary>
        /// Please implement this method to provide the string representation of the datatype
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Batch" + batchID + "-" + isValid + "|type: "+expiryDate;
        }


        /// <summary>
        /// Please implement this method to return a deep clone of the current object
        /// </summary>
        /// <returns></returns>
        public override ExpressionValue GetClone()
        {
            return this;
        }


        /// <summary>
        /// Please implement this method to provide the compact string representation of the datatype
        /// </summary>
        /// <returns></returns>
        public override string ExpressionID
        {
            get {return batchID+""; }
        }

        public int BatchID { get => batchID; set => batchID = value; }
        
    }
    
    
    public class Vial: ExpressionValue {
    	
    	
    	//default constructor
    	public Vial() { Vial = new List<Batch>(); }

        public void useVial(Vial vial){
            batch.
        }
    	public Batch GetBlock(int index){
    		return Vial[index];
    	}
    	
    	public Batch GetBlockCopy(int index){
    		return new Batch(Vial[index]);
    	}
    	
    	public int BlockSize() { return Vial.Count;}
    	
    	        /// <summary>
        /// Please implement this method to provide the string representation of the datatype
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string returnString = "";
            foreach (Batch entry in Vial) {
                returnString +=  entry.ToString() + ";";
            }

            return returnString;

        }


        /// <summary>
        /// Please implement this method to return a deep clone of the current object
        /// </summary>
        /// <returns></returns>
        public override ExpressionValue GetClone()
        {
            return this;
        }


        /// <summary>
        /// Please implement this method to provide the compact string representation of the datatype
        /// </summary>
        /// <returns></returns>
        public override string ExpressionID
        {
            get {
            string returnString = "";
            foreach (Batch entry in Vial) {
                returnString +=  entry.ToString() + ";";
            }

            return returnString;
            }
        }
    
    }
    /// <summary>
    /// The math library that can be used in your model.
    /// all methods should be declared as public static.
    /// 
    /// The parameters must be of type "int", or "int array"
    /// The number of parameters can be 0 or many
    /// 
    /// The return type can be bool, int or int[] only.
    /// 
    /// The method name will be used directly in your model.
    /// e.g. call(max, 10, 2), call(dominate, 3, 2), call(amax, [1,3,5]),
    /// 
    /// Note: method names are case sensetive
    /// </summary>
    public class BlockChain : ExpressionValue
    {
		public Hashtable table;
		public int curID;
		
		public BlockChain(){
			table = new Hashtable();
		}
		
		public void Add(Batch batch){
			table.Add(batch.batchID, batch);
			curID = batch.batchID;
		}
		
		public int BlockChainSize() {return table.Count;}
		
		public int GetCurBlock() { return curID;}
		public Batch GetBlock(int ID) { return (Batch)table[ID];}
        /// <summary>
        /// Please implement this method to provide the string representation of the datatype
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string returnString = "";
            foreach (DictionaryEntry entry in table) {
                returnString +=  entry.Key + "=" + entry.Value.ToString() + ",";
            }

            return returnString;

        }


        /// <summary>
        /// Please implement this method to return a deep clone of the current object
        /// </summary>
        /// <returns></returns>
        public override ExpressionValue GetClone()
        {
            return this;
        }


        /// <summary>
        /// Please implement this method to provide the compact string representation of the datatype
        /// </summary>
        /// <returns></returns>
        public override string ExpressionID
        {
            get {
            string returnString = "";
            foreach (DictionaryEntry entry in table) {
                returnString +=  entry.Key + "=" + entry.Value.ToString() + ",";
            }

            return returnString;
            }
        }

    }
}
