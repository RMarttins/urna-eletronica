using Dapper;
using HubCount.Urna.Core.Models.Entities;
using HubCount.Urna.Core.Models.Reports;
using HubCount.Urna.Core.Repositories.Context;
using HubCount.Urna.Core.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace HubCount.Urna.Core.Repositories
{
    public class VoteRepository : BaseRepository<Vote>, IVoteRepository
    {
        public VoteRepository(MySqlContext context, IConfiguration config) : base(context, config) { }


        public async Task<IEnumerable<VotesResult>> GetVotesResultAsync()
        {
            var query = @"
                SELECT
	                CAN.CANDIDATE_NAME President,
	                CAN.VICE_NAME VicePresident,
                    CAN.LEGENDA Legenda,
                    CAN.PARTIDO Partido,
                    COUNT(VOT.ID) TotalVotes,
                    (SELECT COUNT(ID) FROM TB_VOTE WHERE TYPE_VOTE = 1) TotalValidos,
					(SELECT COUNT(ID) FROM TB_VOTE WHERE TYPE_VOTE = 2) TotalBrancos,
					(SELECT COUNT(ID) FROM TB_VOTE WHERE TYPE_VOTE = 3) TotalNulos
                FROM TB_VOTE VOT
                RIGHT JOIN TB_CANDIDATE CAN
                ON VOT.CANDIDATE_ID = CAN.ID
                GROUP BY CAN.CANDIDATE_NAME
                ORDER BY TotalVotes DESC;";

            var result = await Conexao.QueryAsync<VotesResult>(
                sql: query);

            return result;
        }
    }
}