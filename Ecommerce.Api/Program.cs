var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Artık bu satır hata vermemeli

var app = builder.Build();

// HTTP isteklerini yönet
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      // Bu da düzelmeli
    app.UseSwaggerUI();    // Bu da düzelmeli
}

app.UseHttpsRedirection();

app.Run();