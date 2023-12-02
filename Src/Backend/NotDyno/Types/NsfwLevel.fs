namespace NotDyno.Types

/// https://discord.com/developers/docs/resources/guild#guild-object-guild-nsfw-level
type NsfwLevel =
    | Default = 0
    | Explicit = 1
    | Safe = 2
    | AgeRestricted = 3
