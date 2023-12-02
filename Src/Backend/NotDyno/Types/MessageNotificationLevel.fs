namespace NotDyno.Types

/// https://discord.com/developers/docs/resources/guild#guild-object-default-message-notification-level
type MessageNotificationLevel =
    /// members will receive notifications for all messages by default
    | AllMessages = 0

    /// members will receive notifications only for messages that @mention them by default
    | OnlyMentions = 1
