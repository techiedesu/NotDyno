open System
open Microsoft.Data.Sqlite

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

/// https://discord.com/developers/docs/resources/guild#guild-object-system-channel-flags
[<Flags>]
type SystemChannelFlags =
    /// Suppress member join notifications
    | SuppressJoinNotifications = (1 <<< 0)

    /// Suppress server boost notifications
    | SuppressPremiumSubscriptions = (1 <<< 1)

    /// Suppress server setup tips
    | SuppressGuildReminderNotifications = (1 <<< 2)

    /// Hide member join sticker reply buttons
    | SuppressJoinNotificationReplies = (1 <<< 3)

    /// Suppress role subscription purchase and renewal notifications
    | SuppressRoleSubscriptionPurchaseNotifications = (1 <<< 4)

    /// Hide role subscription sticker reply buttons
    | SuppressRoleSubscriptionPurchaseNotificationReplies = (1 <<< 5)

/// https://discord.com/developers/docs/resources/guild#guild-object-mfa-level
type MfaLevel =
    /// guild has no MFA/2FA requirement for moderation actions
    | None = 0

    /// guild has a 2FA requirement for moderation actions
    | Elevated = 1

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

/// https://discord.com/developers/docs/resources/webhook#webhook-object-webhook-structure
type WebhookRequest = {
    /// the id of the webhook
    Id: Snowflake

    /// the type of the webhook
    Type: Type

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

and Type =
    /// Incoming Webhooks can post messages to channels with a generated token
    | Incoming = 1

    /// Channel Follower Webhooks are internal webhooks used with
    /// Channel Following to post new messages into channels
    | ``Channel Follower`` = 2

    /// Application webhooks are webhooks used with Interactions
    | Application = 3

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

and PremiumType =
    | None = 0
    | ``Nitro Classic`` = 1
    | Nitro = 2
    | ``Nitro Basic`` = 3

and LocaleType =
    | Indonesian
    | Danish
    | German
    | ``English, UK``
    | ``English, US``
    | Spanish
    | French
    | Croatian
    | Italian
    | Lithuanian
    | Hungarian
    | Dutch
    | Norwegian
    | Polish
    | ``Portuguese, Brazilian``
    | ``Romanian, Romania``
    | Finnish
    | Swedish
    | Vietnamese
    | Turkish
    | Czech
    | Greek
    | Bulgarian
    | Russian
    | Ukrainian
    | Hindi
    | Thai
    | ``Chinese, China``
    | Japanese
    | ``Chinese, Taiwan``
    | Korean
    | Other of name: string

/// https://discord.com/developers/docs/resources/channel#channel-object
and Channel = {
    /// the id of this channel
    Id: Snowflake

    /// the type of channel
    Type: ChannelType

    /// the id of the guild (may be missing for some channel objects received over gateway guild dispatches)
    GuidId: Snowflake
}

/// https://discord.com/developers/docs/resources/channel#channel-object-channel-types
and ChannelType =
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

/// https://discord.com/developers/docs/resources/guild#guild-object-verification-level
and VerificationLevel =
    /// unrestricted
    | None = 0

    /// must have verified email on account
    | Low = 1

    /// must be registered on Discord for longer than 5 minutes
    | Medium = 2

    /// must be a member of the server for longer than 10 minutes
    | High = 3

    /// must have a verified phone number
    | VeryHigh = 4

/// https://discord.com/developers/docs/resources/guild#guild-object-default-message-notification-level
and MessageNotificationLevel =
    /// members will receive notifications for all messages by default
    | AllMessages = 0

    /// members will receive notifications only for messages that @mention them by default
    | OnlyMentions = 1

/// https://discord.com/developers/docs/resources/guild#guild-object-explicit-content-filter-level
and ExplicitContentFilterLevel =
    /// media content will not be scanned
    | Disabled = 0

    /// media content sent by members without roles will be scanned
    | MembersWithoutRoles = 1

    /// media content sent by all members will be scanned
    | AllMembers = 2

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

/// https://discord.com/developers/docs/resources/guild#guild-object-guild-features
and GuildFeatures =
    /// guild has access to set an animated guild banner image
    | AnimatedBanner

    /// guild has access to set an animated guild icon
    | AnimatedIcon

    /// guild is using the old permissions configuration behavior
    | ApplicationCommandPermissionsV2

    /// guild has set up auto moderation rules
    | AutoModeration

    /// guild has access to set a guild banner image
    | Banner

    /// guild can enable welcome screen,
    /// Membership Screening, stage channels and discovery,
    /// and receives community updates
    | Community

    /// guild has enabled monetization
    | CreatorMonetizableProvisional

    /// guild has enabled the role subscription promo page
    | CreatorStorePage

    /// guild has been set as a support server on the App Directory
    | DeveloperSupportServer

    /// guild is able to be discovered in the directory
    | Discoverable

    /// guild is able to be featured in the directory
    | Featurable

    /// guild has paused invites, preventing new users from joining
    | InvitesDisabled

    /// guild has access to set an invite splash background
    | InviteSplash

    /// guild has enabled Membership Screening
    | MemberVerificationGateEnabled

    /// guild has increased custom sticker slots
    | MoreStickers

    /// guild has access to create announcement channels
    | News

    /// guild is partnered
    | Partnered

    /// guild can be previewed before joining
    /// via Membership Screening or the directory
    | PreviewEnabled

    /// guild has disabled alerts for join raids
    /// in the configured safety alerts channel
    | RaidAlertsDisabled

    /// guild is able to set role icons
    | RoleIcons

    /// guild has role subscriptions that can be purchased
    | RoleSubscriptionsAvailableForPurchase

    /// guild has enabled role subscriptions
    | RoleSubscriptionsEnabled

    /// guild has enabled ticketed events
    | TicketedEventsEnabled

    /// guild has access to set a vanity URL
    | VanityUrl

    /// guild is verified
    | Verified

    /// guild has access to set 384kbps bitrate
    /// in voice (previously VIP voice servers)
    | VipRegions

    /// guild has enabled the welcome screen
    | WelcomeScreenEnabled

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

/// https://discord.com/developers/docs/resources/guild#guild-object-guild-nsfw-level
and NsfwLevel =
    | Default = 0
    | Explicit = 1
    | Safe = 2
    | AgeRestricted = 3

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

/// https://discord.com/developers/docs/resources/sticker#sticker-object-sticker-types
and StickerType =
    /// an official sticker in a pack
    | Standard = 1

    /// a sticker uploaded to a guild for the guild's members
    | Guild = 2

/// https://discord.com/developers/docs/resources/sticker#sticker-object-sticker-format-types
and StickerFormat =
    | Png = 1
    | Apng = 2
    | Lottie = 3
    | Gif = 4
