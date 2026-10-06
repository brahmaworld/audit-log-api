
CREATE TABLE audit_log (
    id BIGSERIAL PRIMARY KEY,

    event_type VARCHAR(100) NOT NULL,
    actor_id VARCHAR(255) NOT NULL,

    resource_type VARCHAR(100) NOT NULL,
    resource_id VARCHAR(255) NOT NULL,

    --payload JSONB NOT NULL DEFAULT '{}'::jsonb,

    -- Server-assigned time when the audit record is stored
    timestamp TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,

    -- SHA-256 hash of the event's canonical content
    content_hash CHAR(64) NOT NULL,

    -- SHA-256 hash of the immediately preceding record.
    -- Genesis value is used for the first record.
    previous_hash CHAR(64) NOT NULL,

);

CREATE INDEX idx_audit_log_actor_id
    ON audit_log(actor_id);

CREATE INDEX idx_audit_log_resource
    ON audit_log(resource_type, resource_id);

CREATE INDEX idx_audit_log_timestamp
    ON audit_log(timestamp);

CREATE INDEX idx_audit_log_event_type
    ON audit_log(event_type);