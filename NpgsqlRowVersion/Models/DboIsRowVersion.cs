namespace NpgsqlRowVersion.Models;

public class DboIsRowVersion
{
    public int Id { get; set; }

    public int Col1 { get; set; }

    public uint RowVersion { get; set; }
}
