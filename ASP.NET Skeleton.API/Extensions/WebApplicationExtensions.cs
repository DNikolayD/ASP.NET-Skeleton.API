namespace ASP.NET_Skeleton.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void ConfigureWebSettings(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
