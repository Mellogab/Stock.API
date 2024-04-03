using AutoMapper;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Stock.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<HtmlNode, Core.Entities.Adapters.StockFromInternet>()
                .ForMember(dest => dest.Paper, opt => opt.MapFrom(
                    src => src.SelectSingleNode("td[1]").InnerText.Trim()
                ))
                .ForMember(dest => dest.Quotation, opt => opt.MapFrom(
                    src => src.SelectSingleNode("td[2]").InnerHtml.Trim()
                ))
                .ForMember(dest => dest.PEBIT, opt => opt.MapFrom(src =>
                    src.SelectSingleNode("td[9]").InnerHtml.Trim()
                ))
                .ForMember(dest => dest.EVEBIT, opt => opt.MapFrom(src =>
                    src.SelectSingleNode("td[11]").InnerHtml.Trim()
                ))
                .ForMember(dest => dest.EVEBITDA, opt => opt.MapFrom(src =>
                    src.SelectSingleNode("td[12]").InnerHtml.Trim()
                ))
                .ForMember(dest => dest.VolumeTraded, opt => opt.MapFrom(src =>
                    src.SelectSingleNode("td[18]").InnerHtml.Trim()
                ))
                .ForMember(dest => dest.DividendYield, opt => opt.MapFrom(src =>
                    src.SelectSingleNode("td[6]").InnerHtml.Trim().Replace("%", "")
                ))
                .ForMember(dest => dest.ROIC, opt => opt.MapFrom(src =>
                    src.SelectSingleNode("td[16]").InnerHtml.Trim().Replace("%", "")
                ))
                .ForMember(dest => dest.ROE, opt => opt.MapFrom(src =>
                    src.SelectSingleNode("td[17]").InnerHtml.Trim().Replace("%", "")
                ))
                .ForMember(dest => dest.NetEquity, opt => opt.MapFrom(src =>
                    src.SelectSingleNode("td[19]").InnerHtml.Trim()
                ))
                .ReverseMap();

            CreateMap<HtmlNode, Core.Entities.Stock>()
                .ForMember(dest => dest.Paper, opt => opt.MapFrom(
                    src => src.SelectSingleNode("td[1]").InnerText.Trim()
                ))
                .ForMember(dest => dest.Quotation, opt => opt.MapFrom(
                    src => float.Parse(src.SelectSingleNode("td[2]").InnerHtml.Trim()) 
                ))
                .ForMember(dest => dest.PEBIT, opt => opt.MapFrom(src =>
                   float.Parse(src.SelectSingleNode("td[9]").InnerHtml.Trim()) 
                ))
                .ForMember(dest => dest.EVEBIT, opt => opt.MapFrom(src =>
                    float.Parse(src.SelectSingleNode("td[11]").InnerHtml.Trim()) 
                ))
                .ForMember(dest => dest.EVEBITDA, opt => opt.MapFrom(src =>
                    float.Parse(src.SelectSingleNode("td[12]").InnerHtml.Trim()) 
                ))
                .ForMember(dest => dest.VolumeTraded, opt => opt.MapFrom(src =>
                    float.Parse(src.SelectSingleNode("td[18]").InnerHtml.Trim()) 
                ))
                .ForMember(dest => dest.DividendYield, opt => opt.MapFrom(src =>
                    src.SelectSingleNode("td[6]").InnerHtml.Trim()
                ))
                .ForMember(dest => dest.ROIC, opt => opt.MapFrom(src =>
                    src.SelectSingleNode("td[16]").InnerHtml.Trim()
                ))
                .ForMember(dest => dest.ROE, opt => opt.MapFrom(src =>
                    src.SelectSingleNode("td[17]").InnerHtml.Trim()
                ))
                //.ForMember(dest => dest.NetEquity, opt => opt.MapFrom(src =>
                //    float.Parse(src.SelectSingleNode("td[19]").InnerHtml.Trim()) 
                //))
                .ReverseMap();
        }
    }
}
