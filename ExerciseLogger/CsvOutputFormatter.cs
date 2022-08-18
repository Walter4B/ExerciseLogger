using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;

namespace ExerciseLogger
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(GymDto).IsAssignableFrom(type) || typeof(IEnumerable<GymDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        { 
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<GymDto>)
            {
                foreach (var gym in (IEnumerable<GymDto>)context.Object)
                {
                    FormatCsv(buffer, gym);
                }
            }
            else
            {
                FormatCsv(buffer, (GymDto)context.Object);
            }

            await response.WriteAsync(buffer.ToString());
        }

        public static void FormatCsv(StringBuilder buffer, GymDto gym)
        {
            buffer.AppendLine($"{gym.Id},\"{gym.Name},\"{gym.Address}\"");
        }
    }
}
