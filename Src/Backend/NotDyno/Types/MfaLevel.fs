namespace NotDyno.Types

/// https://discord.com/developers/docs/resources/guild#guild-object-mfa-level
type MfaLevel =
    /// guild has no MFA/2FA requirement for moderation actions
    | None = 0

    /// guild has a 2FA requirement for moderation actions
    | Elevated = 1
