using System;

namespace Finora.Domain.Entities;

public class User
{

}

// | Column         | Type     | Notes                   |
// | -------------- | -------- | ----------------------- |
// | `Id`           | Guid     | Primary Key             |
// | `Email`        | string   | Unique                  |
// | `PasswordHash` | string   | Hashed (store securely) |
// | `CreatedAt`    | DateTime |                         |
