namespace NotDyno.Types

/// https://discord.com/developers/docs/resources/guild#guild-object-guild-features
type GuildFeatures =
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
