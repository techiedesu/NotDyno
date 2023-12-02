namespace NotDyno.Types

/// https://discord.com/developers/docs/resources/guild#guild-object-premium-tier
type PremiumTier =
    /// guild has not unlocked any Server Boost perks
    | None = 0

    /// guild has unlocked Server Boost level 1 perks
    | Tier1 = 1

    /// guild has unlocked Server Boost level 2 perks
    | Tier2 = 2

    /// guild has unlocked Server Boost level 3 perks
    | Tier3 = 3
