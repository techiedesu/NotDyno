open System
open Microsoft.Data.Sqlite
open NotDyno.Types

type Snowflake = Guid

type WebhookInfo = {
    Id: Guid
    GuildId: Snowflake
    CreatedAt: DateTimeOffset
    UpdatedAt: DateTimeOffset option
}

let createStorage (connectionString: string) =
    use connection = new SqliteConnection(connectionString)

    let tryMigrate () = task {
        ()
    }

    let getAllWebhooks () = task {
        ()
    }

    tryMigrate, getAllWebhooks

/// https://discord.com/developers/docs/resources/webhook#webhook-object-webhook-structure
type WebhookRequest = {
    /// the id of the webhook
    Id: Snowflake

    /// the type of the webhook
    Type: WebhookRequestType

    /// the guild id this webhook is for, if any
    GuildId: Snowflake option

    /// the channel id this webhook is for, if any
    ChannelId: Snowflake option

    /// the user this webhook was created by
    /// (not returned when getting a webhook with its token)
    User: User option

    /// the default name of the webhook
    Name: string option

    /// the default user avatar hash of the webhook
    Avatar: string option

    /// the secure token of the webhook
    /// (returned for Incoming Webhooks)
    Token: string option

    /// the bot/OAuth2 application that created this webhook
    ApplicationId: Snowflake option

    /// the channel that this webhook is following
    /// (returned for Channel Follower Webhooks)
    SourceGuild: Guild option

    /// he url used for executing the webhook
    /// (returned by the webhooks OAuth2 flow)
    Url: string
}

/// https://discord.com/developers/docs/resources/user#user-object
and User = {
    /// the user's id
    Id: Snowflake

    /// the user's username, not unique across the platform
    UserName: string

    /// the user's Discord-tag
    Discriminator: string

    /// the user's display name, if it is set.
    /// For bots, this is the application name
    GlobalName: string

    /// the user's avatar hash
    Avatar: string option

    /// whether the user belongs to an OAuth2 application
    Bot: bool option

    /// whether the user is an Official Discord System user
    /// (part of the urgent message system)
    System: bool

    /// whether the user has two factor enabled on their account
    MfaEnabled: bool option

    /// the user's banner hash
    Banner: string option

    /// the user's banner color encoded as an integer
    /// representation of hexadecimal color code
    AccentColor: int option

    /// the user's chosen language option
    Locale: LocaleType option

    /// whether the email on this account has been verified
    Verified: bool option

    /// the user's email
    Email: string option

    /// the flags on a user's account
    Flags: int option

    /// the type of Nitro subscription on a user's account
    PremiumType: PremiumType option

    /// the public flags on a user's account
    PublicFlags: int option

    /// the user's avatar decoration hash
    AvatarDecoration: string option
}

/// https://discord.com/developers/docs/resources/channel#channel-object
and Channel = {
    /// the id of this channel
    Id: Snowflake

    /// the type of channel
    Type: ChannelType

    /// the id of the guild (may be missing for some channel objects received over gateway guild dispatches)
    GuidId: Snowflake
}

/// https://discord.com/developers/docs/resources/channel#overwrite-object
and Overwrite = {
    /// role or user id
    Id: Snowflake

    /// either 0 (role) or 1 (member)
    Type: OverwriteType

    /// permission bit set
    Allow: string

    /// permission bit set
    Deny: string
}

and OverwriteType =
    | Role = 0
    | Member = 1

/// https://discord.com/developers/docs/resources/guild#guild-object
and Guild = {
    /// guild id
    Id: Snowflake

    /// guild name (2-100 characters, excluding trailing and leading whitespace)
    Name: string

    /// icon hash
    Icon: string option

    /// icon hash, returned when in the template object
    IconHash: string option

    /// splash hash
    Splash: string option

    /// discovery splash hash; only present for guilds with the "DISCOVERABLE" feature
    DiscoverySplash: string option

    /// true if the user is the owner of the guild
    Owner: bool option

    /// id of owner
    OwnerId: Snowflake

    /// total permissions for the user in the guild (excludes overwrites and implicit permissions)
    Permissions: string option

    /// voice region id for the guild (deprecated)
    Region: string option

    /// id of afk channel
    AfkChannelId: Snowflake option

    /// afk timeout in seconds
    AfkTimeout: int

    /// true if the server widget is enabled
    WidgetEnabled: bool option

    /// the channel id that the widget will generate an invite to, or null if set to no invite
    WidgetChannelId: Snowflake option

    /// verification level required for the guild
    VerificationLevel: VerificationLevel

    /// default message notifications level
    DefaultMessageNotifications: MessageNotificationLevel

    /// explicit content filter level
    ExplicitContentFilter: ExplicitContentFilterLevel

    /// roles in the guild
    Roles: Role[]

    /// custom guild emojis
    Emojis: Emoji[]

    /// enabled guild features
    Features: GuildFeatures[]

    /// required MFA level for the guild
    MfaLevel: MfaLevel

    /// application id of the guild creator if it is bot-created
    ApplicationId: Snowflake option

    /// the id of the channel where
    /// guild notices such as welcome messages and boost events are posted
    SystemChannelId: Snowflake option

    /// system channel flags
    SystemChannelFlags: SystemChannelFlags

    /// the id of the channel where Community guilds can display rules and/or guidelines
    RulesChannelId: Snowflake option

    /// the maximum number of presences for the guild
    /// (null is always returned, apart from the largest of guilds)
    MaxPresences: int option

    /// the maximum number of members for the guild
    MaxMembers: int option

    /// the vanity url code for the guild
    VanityUrlCode: string option

    /// the description of a guild
    Description: string option

    /// banner hash
    Banner: string option

    /// premium tier (Server Boost level)
    PremiumTier: PremiumTier

    /// the number of boosts this guild currently has
    PremiumSubscriptionCount: int option

    /// the preferred locale of a Community guild;
    /// used in server discovery and notices from Discord,
    /// and sent in interactions; defaults to "en-US"
    PreferredLocale: LocaleType

    /// the id of the channel where admins and moderators of
    /// Community guilds receive notices from Discord
    PublicUpdatesChannelId: Snowflake option

    /// the maximum amount of users in a video channel
    MaxVideoChannelUsers: int option

    /// the maximum amount of users in a stage video channel
    MaxStageVideoChannelUsers: int option

    /// approximate number of members in this guild,
    /// returned from the GET /guilds/<id> and /users/@me/guilds endpoints
    /// when with_counts is true
    ApproximateMemberCount: int option

    /// 	approximate number of non-offline members in this guild,
    /// returned from the GET /guilds/<id>
    /// and /users/@me/guilds endpoints when with_counts is true
    ApproximatePresenceCount: int option

    /// the welcome screen of a Community guild, shown to new members,
    /// returned in an Invite's guild object
    WelcomeScreen: WelcomeScreen option

    /// guild NSFW level
    NsfwLevel: NsfwLevel

    /// custom guild stickers
    Stickers: Sticker[]

    /// whether the guild has the boost progress bar enabled
    PremiumProgressBarEnabled: bool

    /// the id of the channel where admins and moderators of Community
    /// guilds receive safety alerts from Discord
    SafetyAlertsChannelId: Snowflake option
}



/// https://discord.com/developers/docs/topics/permissions#role-object
and Role = {
    /// role id
    Id: Snowflake

    /// role name
    Name: string

    /// integer representation of hexadecimal color code
    Color: int

    /// if this role is pinned in the user listing
    Hoist: bool

    /// role icon hash
    Icon: string option

    /// role unicode emoji
    UnicodeEmoji: string option

    /// position of this role
    Position: int

    /// permission bit set
    Permissions: string

    /// whether this role is managed by an integration
    Managed: bool

    /// whether this role is mentionable
    Mentionable: bool

    /// the tags this role has
    Tags: RoleTag[] option

    /// role flags combined as a bitfield
    Flags: int
}

/// https://discord.com/developers/docs/topics/permissions#role-object-role-tags-structure
and RoleTag = {
    /// the id of the bot this role belongs to
    BotId: Snowflake option

    /// the id of the integration this role belongs to
    IntegrationId: Snowflake option

    /// the id of this role's subscription sku and listing
    SubscriptionListingId: Snowflake option

    // TODO: add premium_subscriber, available_for_purchase, guild_connections
}

/// https://discord.com/developers/docs/resources/emoji#emoji-object
and Emoji = {
    /// emoji id
    Id: Snowflake option

    /// emoji name
    Name: string

    /// roles allowed to use this emoji
    Roles: Role[] option

    /// user that created this emoji
    User: User option

    /// whether this emoji must be wrapped in colons
    RequireColons: bool option

    /// whether this emoji is managed
    Managed: bool option

    /// whether this emoji is animated
    Animated: bool option

    /// whether this emoji can be used,
    /// may be false due to loss of Server Boosts
    Available: bool option
}

/// https://discord.com/developers/docs/resources/guild#welcome-screen-object
and WelcomeScreen = {
    /// the server description shown in the welcome screen
    Description: string option
    WelcomeScreenChannels: WelcomeScreenChannel[]
}

/// https://discord.com/developers/docs/resources/guild#welcome-screen-object-welcome-screen-channel-structure
and WelcomeScreenChannel = {
    /// the channel's id
    ChannelId: Snowflake

    /// the description shown for the channel
    Description: string

    /// the emoji id, if the emoji is custom
    EmojiId: Snowflake option

    /// the emoji name if custom, the unicode character if standard,
    /// or null if no emoji is set
    EmojiName: string option
}

/// https://discord.com/developers/docs/resources/sticker#sticker-object
and Sticker = {
    /// id of the sticker
    Id: Snowflake

    /// for standard stickers, id of the pack the sticker is from
    PackId: Snowflake option

    /// name of the sticker
    Name: string

    /// description of the sticker
    Description: string option

    /// autocomplete/suggestion tags for the sticker (max 200 characters)
    Tags: string

    /// Deprecated previously the sticker asset hash, now an empty string
    Asset: string option

    /// type of sticker
    Type: StickerType

    /// type of sticker format
    FormatType: StickerFormat

    /// whether this guild sticker can be used, may be false due to loss of Server Boosts
    Available: bool option

    /// id of the guild that owns this sticker
    GuildId: Snowflake option

    /// the user that uploaded the guild sticker
    User: User option

    /// the standard sticker's sort order within its pack
    SortValue: int option
}
