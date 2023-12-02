namespace NotDyno.Types

/// https://discord.com/developers/docs/resources/sticker#sticker-object-sticker-types
type StickerType =
    /// an official sticker in a pack
    | Standard = 1

    /// a sticker uploaded to a guild for the guild's members
    | Guild = 2
