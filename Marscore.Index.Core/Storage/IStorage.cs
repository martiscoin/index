using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marscore.Index.Core.Models;

using Marscore.Index.Core.Storage.Types;

namespace Marscore.Index.Core.Storage
{
   public interface IStorage
   {
      SyncBlockInfo GetLatestBlock();
        List<SyncBlockInfo> GetLatestBlocks();

        int GetMemoryTransactionsCount();

      QueryAddress AddressBalance(string address);

      Task<List<QueryAddressBalance>> QuickBalancesLookupForAddressesWithHistoryCheckAsync(
         IEnumerable<string> addresses, bool includePending = false);

      QueryResult<QueryAddressItem> AddressHistory(string address, int? offset, int limit);

      QueryResult<QueryMempoolTransactionHashes> GetMemoryTransactionsSlim(int offset, int limit);

      QueryResult<QueryTransaction> GetMemoryTransactions(int offset, int limit);

      string GetRawTransaction(string transactionId);

      QueryTransaction GetTransaction(string transactionId);

      QueryResult<SyncTransactionInfo> TransactionsByBlock(string hash, int offset, int limit);

      QueryResult<SyncTransactionInfo> TransactionsByBlock(long index, int offset, int limit);

      QueryResult<SyncBlockInfo> Blocks(int? offset, int limit,int ispow);

      SyncBlockInfo BlockByHash(string blockHash);

      string GetRawBlock(string blockHash);

      SyncBlockInfo BlockByIndex(long blockIndex);

      QueryResult<QueryOrphanBlock> OrphanBlocks(int? offset, int limit);

      T OrphanBlockByHash<T>(string blockHash) where T : class;

      QueryResult<BalanceForAddress> Richlist(int offset, int limit);

      List<BalanceForAddress> AddressBalances(IEnumerable<string> addresses);

      long TotalBalance();

      Task<QueryResult<Output>> GetUnspentTransactionsByAddressAsync(string address,long confirmations, int offset, int limit);

      Task DeleteBlockAsync(string blockHash);

      public List<string> GetBlockIndexIndexes();

      public List<string> GetMempoolTransactionIds();

      public bool DeleteTransactionsFromMempool(List<string> transactionIds);

      List<PeerDetails> GetPeerFromDate(DateTime date);
      Task<long> InsertPeer(PeerDetails info);
   }
}
