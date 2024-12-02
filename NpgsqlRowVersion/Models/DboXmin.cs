namespace NpgsqlRowVersion.Models;

public class DboXmin
{
    public int Id { get; set; }

    public int Col1 { get; set; }

    public uint RowVersion { get; set; }
}
