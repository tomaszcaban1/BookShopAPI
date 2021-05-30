using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShopAPI.Migrations
{
    public partial class spSelectBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
            IF OBJECT_ID('SelectBooks', 'P') IS NOT NULL
            DROP PROC SelectBooks
            GO

            SET ANSI_NULLS ON
            GO

            SET QUOTED_IDENTIFIER ON
            GO

 
            CREATE PROCEDURE [dbo].[SelectBooks] 
			(
				@PageNumber int
				, @RowsOfPage int
				, @SortedBy nvarchar(10) = 'Id'
				, @SortDirection nvarchar(4) = 'ASC'
				, @SearchAuthor nvarchar(30) = ''
			)
            AS
            BEGIN
			    DECLARE @sql NVARCHAR(MAX);
				DECLARE @result int = (@PageNumber-1)*@RowsOfPage;

				SET @sql = N'
                SELECT 
					* 
				FROM 
					dbo.Books as Books			
					WHERE 
					Books.Author like ''%' + @SearchAuthor + '%''
				ORDER BY (SELECT ' + QUOTENAME(@SortedBy) + ') ' + @SortDirection
				+ ' OFFSET ' + CONVERT(varchar(10), @result)  + ' ROWS '
				+ ' FETCH NEXT ' + CONVERT(varchar(10), @RowsOfPage)  + ' ROWS ONLY;';

				print @sql;
				EXEC sp_executesql @sql;
            END

			
            GO";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC SelectBooks");
        }
    }
}
