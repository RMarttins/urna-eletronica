using Dapper;
using HubCount.Urna.Core.Models.Entities;
using HubCount.Urna.Core.Repositories.Context;
using HubCount.Urna.Core.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace HubCount.Urna.Core.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(MySqlContext context, IConfiguration config) : base(context, config) { }

        public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            var query = $@"
                SELECT 
	                ID,
                    CANDIDATE_NAME CandidateName,
                    VICE_NAME ViceName,
                    DT_CREATE DtCreate,
                    LEGENDA Legenda,
                    PARTIDO Partido
                FROM TB_CANDIDATE;";

            var result = await Conexao.QueryAsync<Candidate>(query);

            return result;
        }

        public async Task<Candidate> GetByLegenda(decimal legenda)
        {
            var query = $@"
                SELECT 
	                ID,
                    CANDIDATE_NAME CandidateName,
                    VICE_NAME ViceName,
                    DT_CREATE DtCreate,
                    LEGENDA Legenda,
                    PARTIDO Partido
                FROM TB_CANDIDATE
                WHERE LEGENDA = {ParamSymbol}Legenda;";

            var param = new DynamicParameters();
            param.Add(name: "Legenda", value: legenda, direction: ParameterDirection.Input);

            var result = await Conexao.QuerySingleOrDefaultAsync<Candidate>(
                sql: query,
                param: param);

            return result;
        }

        public async Task<Candidate> GetByPartidoAsync(string partido)
        {
            var query = $@"
                SELECT 
	                ID,
                    CANDIDATE_NAME CandidateName,
                    VICE_NAME ViceName,
                    DT_CREATE DtCreate,
                    LEGENDA Legenda,
                    PARTIDO Partido
                FROM TB_CANDIDATE
                WHERE PARTIDO = {ParamSymbol}Partido;";

            var param = new DynamicParameters();
            param.Add(name: "Partido", value: partido, direction: ParameterDirection.Input);

            var result = await Conexao.QuerySingleOrDefaultAsync<Candidate>(
                sql: query,
                param: param);

            return result;
        }
    }
}