namespace NotDyno.Types

/// https://discord.com/developers/docs/resources/channel#channel-object-channel-types
type ChannelType =
    /// a text channel within a server
    | GuildText = 0

    /// a direct message between users
    | DirectMessage = 1

    /// a voice channel within a server
    | GuildVoice = 2

    /// a direct message between multiple users
    | GroupDirectMessage = 3

    /// an organizational category that contains up to 50 channels
    | GuildCategory = 4

    /// a channel that users can follow and crosspost into their own server
    /// (formerly news channels)
    | GuildAnnouncement = 5

    /// a temporary sub-channel within a GUILD_ANNOUNCEMENT channel
    | AnnouncementThread = 10

    /// temporary sub-channel within a GuildText or GuildForum channel
    | PublicThread = 11

    /// a temporary sub-channel within a GUILD_TEXT channel that is only
    /// viewable by those invited and those with the MANAGE_THREADS permission
    | PrivateThread = 12

    /// a voice channel for hosting events with an audience
    | GuildStageVoice = 13

    /// the channel in a hub containing the listed servers
    | GuildDirectory = 14

    /// Channel that can only contain threads
    | GuildForum = 15

    /// Channel that can only contain threads, similar to GuildForum channels
    | GuildMedia = 16
