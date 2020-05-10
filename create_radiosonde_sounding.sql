DROP TABLE IF EXISTS
    radiosonde.radiosonde_sounding;

CREATE TABLE radiosonde.radiosonde_sounding (
    id varchar(25),
    created_date_time_stamp datetime,
	launch_site_id varchar(25),
	launch_year int,
	launch_month int,
	launch_day int,
	launch_hour int,
	launch_time int,
	number_of_levels_in_sounding int,
	cloud_information varchar(10),
	latitude decimal(15,12),
	longitude decimal(15,12),
	elevation decimal(8,2),
	observation_type varchar(10),
	sonde_type varchar(10),
	serial_number varchar(25),
	serial_number_type varchar(10),
	pressure_correction varchar(10),
	geopotential_height_correction varchar(10),
	temperature_correction varchar(10),
	relative_humidity_correction varchar(10),
	dew_point_correction varchar(10),
	wind_speed_and_direction_correction varchar(10)
);