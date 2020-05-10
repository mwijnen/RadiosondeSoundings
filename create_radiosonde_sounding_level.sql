DROP TABLE IF EXISTS
    radiosonde.radiosonde_sounding_level;

CREATE TABLE radiosonde.radiosonde_sounding_level (
    id varchar(25),
    created_date_time_stamp datetime,
	radiosonde_sounding_id varchar(25),
    elapsed_time varchar(10),
    pressure varchar(10),
    geopotential_height varchar(10),
    temperature varchar(10),
    relative_humidity varchar(10),
    dew_point_depression varchar(10),
    wind_direction varchar(10),
    wind_speed varchar(10)
);