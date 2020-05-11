DROP TABLE IF EXISTS
    radiosonde.radiosonde_sounding_level;

CREATE TABLE radiosonde.radiosonde_sounding_level (
	record_id varchar(25),
    created_date_time_stamp datetime,
	radiosonde_sounding_id varchar(25),
    elapsed_time int,
    pressure decimal(12,4),
    geopotential_height decimal(12,4),
    temperature decimal(12,4),
    relative_humidity decimal(12,4),
    dew_point_depression decimal(12,4),
    wind_direction decimal(12,4),
    wind_speed decimal(12,4)
);