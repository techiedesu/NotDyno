namespace NotDyno.Types

open System

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
