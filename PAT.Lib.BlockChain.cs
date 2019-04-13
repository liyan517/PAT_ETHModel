using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PAT.Common.Classes.Expressions.ExpressionClass;


//the namespace must be PAT.Lib, the class and method names can be arbitrary
namespace PAT.Lib
{
	    public class Block : ExpressionValue
    {
    	public int blockID;
        public bool isValid;
    	public int minerID;
    	public List<int[]> voters = new List<int[]>(3);
    	public int trancType;
    	
    	public Block(){}
    	
    	public Block(int ID, bool val, int miner, int trancT){
    		blockID = ID;
    		isValid = val;
    		minerID = miner;
    		trancType = trancT;
    	}
    	
       public Block(Block blk):this(blk.blockID, blk.isValid, blk.minerID,blk.trancType){
       }
    	
       public void addVoter(int voterid, int vote){
        	if(voters == null) 
        	{
        	  voters = new List<int[]>(3);
        	  
        	}
        	voters.Add(new int[] {voterid, vote});
        	
        }
        
        public int GetVote(int voterid){
        	foreach(int[] vote in voters){
        		if(vote[0]==voterid){
        			return vote[1];
        		}
        	}
        	return 0;
        }
        
        public int GetVoterRewards(int voterid, int total){
        	int vote = this.GetVote(voterid);
        	return (int)Math.Ceiling((double)vote/(double)total * (double)total);
        }
        
        public int countVote() {
        	int count = 0;
        	foreach(int[] voter in voters){
        		count += voter[1];
        	}
        	return count;
        }
        
        public void SetBlockID(int id) {blockID = id;}
        public void SetMinerID(int id) { minerID = id;}
        public void SetValid(bool valid) {isValid = valid;}
        public bool IsValid() {return isValid;}
        public int GetMiner() {return minerID;}
        public int GetBlockID() {return blockID;}
        public int GetTranType() {return trancType;}

        /// <summary>
        /// Please implement this method to provide the string representation of the datatype
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
        	string returnstring = "";
            returnstring += "[block:" + blockID + "][valid:" + isValid + "][type: "+trancType + "][miner:" + minerID+"]";
            foreach(int[] vote in voters){
            	returnstring += "[voter:" + vote[0] + "|cnt:" + vote[1]+"]";
            }
            return returnstring;
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
            get {return blockID+""; }
        }

    }
    
    
    public class BlockList: ExpressionValue {
    	public IList<Block> blockList;
    	
    	//default constructor
    	public BlockList() { blockList = new List<Block>(); }
    	public void Add(Block blk){
    		blockList.Add(blk);
    	}
    	public Block GetBlock(int index){
    		return blockList[index];
    	}
    	
    	public Block GetBlockCopy(int index){
    		return new Block(blockList[index]);
    	}
    	
    	public int BlockSize() { return blockList.Count;}
    	
    	        /// <summary>
        /// Please implement this method to provide the string representation of the datatype
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string returnString = "";
            foreach (Block entry in blockList) {
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
            foreach (Block entry in blockList) {
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
		
		public void Add(Block blk){
			table.Add(blk.blockID, blk);
			curID = blk.blockID;
		}
		
		public int BlockChainSize() {return table.Count;}
		
		public int GetCurBlock() { return curID;}
		public Block GetBlock(int ID) { return (Block)table[ID];}
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
